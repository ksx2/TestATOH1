using TestATOH1.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestATOH1.Models.AuthentificateModels;
using TestATOH1.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using TestATOH1.Models.DataBaseContext;
using TestATOH1.Helpers.Authorize;



namespace TestATOH1.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;
        private IJWTGenerate _jwt;
        private readonly IMapper _mapper;

        public UserRepository(UsersDbContext usersDbContext,IMapper mapper,IJWTGenerate jwt)
        {
            _context = usersDbContext;
            _mapper = mapper;
            _jwt = jwt;
        }
        //AUTHENTICATE
        public async Task<string> Authenticate(AuthenticateRequest model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Login == model.Login);
            if(user == null) 
            {
                throw new AppException("Invalid login");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);

            // validate
            if (!isPasswordValid)
            {
                throw new AppException("Invalid password");
                
            }
            
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwt.GenerateToken(user);
            return response.Token;
        }
        
        //CREATE
        public async Task<UserModel> Create(UserCreateRequestModel userCreate)
        {
            
                if (userCreate == null)
                {
                    throw new AppException("Invalid data");
                }
                
                var user = _mapper.Map<UserModel>(userCreate);//Mapping userCreate -> user
                var uniqueLogin = await _context.Users.FirstOrDefaultAsync(u => u.Login == userCreate.Login);
                if (uniqueLogin != null) 
                {
                throw new AppException("User with this login is already exists");
                }
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userCreate.Password);//hashing password from userCreate to user(Bcrypt Nuget Package)
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
                
            
        }

        //READ
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            if (_context.Users == null) throw new KeyNotFoundException("Users not found"); 

            return await _context.Users.Where(u => u.RevokedOn == DateTime.MaxValue).OrderBy(u => u.CreatedOn).ToListAsync<UserModel>();
            
        }
        public async Task<UserGetByLoginResponseModel> GetByLogin(string login)
        {
            if (_context.Users == null) throw new KeyNotFoundException("Users not found"); 

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
            {
                throw new KeyNotFoundException("User with this login not found");
            }
            var response = _mapper.Map<UserGetByLoginResponseModel>(user);
            response.Available = user.RevokedOn != DateTime.MaxValue ? false: true;
            return response;
        }
        public async Task<UserModel> GetByLoginAndPassword(string login,string password)
        {
            if (_context.Users == null) throw new KeyNotFoundException("Users not found");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.RevokedOn == DateTime.MaxValue);
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isPasswordValid && user == null)
            {
                throw new AppException("Invalid password or login(maybe your account was removed");
            }
            return user;
        }
        public async Task<IEnumerable<UserModel>> GetOlderThanSmthAge(int old)
        {
            if (_context.Users == null) throw new KeyNotFoundException("Users not found"); 

            return await _context.Users.Where(u => u.Birthday.Value.AddDays(old*365)<DateTime.Now).ToListAsync<UserModel>();
        }

        //REMOVE
        public async Task<UserModel> RemoveFull(string login)
        {
            if (_context.Users == null) throw new KeyNotFoundException("Users not found");
            var searchUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (searchUser == null)
            {
                throw new KeyNotFoundException("User with this login not found");
            }
            _context.Remove(_context.Users.Single(x=> x == searchUser));
            await _context.SaveChangesAsync();
            return searchUser;
        }
        public async Task<UserModel> RemoveSoft(string login,string RevokedBy)
        {
            if (_context.Users == null) throw new KeyNotFoundException("Users not found");
            var searchUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (searchUser == null)
            {
                throw new KeyNotFoundException("User with this login not found");
            }

            searchUser.RevokedOn = DateTime.Now;
            searchUser.RevokedBy = RevokedBy;
            await _context.SaveChangesAsync();
            return searchUser;
        }

        //UPDATE
        public async Task<UserModel> UpdateUsernameGenderBirthday(string login, UserUpdateNameGenderBirthdayRequestModel user,string name)
        {
            var modifyFlag = false;
            var searchUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (searchUser == null)
            {
                throw new KeyNotFoundException("User with this login not found");
            }

            if (user.Name != null)
            {
                searchUser.Name = user.Name;
                modifyFlag = true;
            }
            if (user.Gender != null)
            {
                searchUser.Gender = (int)user.Gender;
                modifyFlag = true;

            }
            if (user.Birthday != null)
            {
                searchUser.Birthday = (DateTime)user.Birthday;
                modifyFlag = true;

            }
            if (modifyFlag)
            {
                searchUser.ModifiedBy = name;
                searchUser.ModifiedOn = DateTime.Now;
            }
            await _context.SaveChangesAsync();
            return searchUser;
        }
        public async Task<string> UpdatePassword(string login, string password,string name)
        {
            var searchUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == login && x.RevokedOn == DateTime.MaxValue);
            if (searchUser == null)
            {
                throw new KeyNotFoundException("User with this login not found");
            }
            searchUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            searchUser.ModifiedBy = name;
            searchUser.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return $"User password with login {searchUser.Login} was updated";
        }

        public async Task<string> UpdateLogin(string startLogin,string endLogin, string name)
        {
            var searchUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == startLogin && x.RevokedOn == DateTime.MaxValue);
            if (searchUser == null)
            {
                throw new KeyNotFoundException("User with this login not found");
            }
            if (_context.Users.Any(u => u.Login == endLogin)) throw new AppException("Login is busy");
            searchUser.Login = endLogin;
            searchUser.ModifiedBy = name;
            searchUser.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return $"User with login {startLogin} was updated to {searchUser.Login}";
        }

        public async Task<UserModel> UpdateRevoked(string login, string name)
        {
            var searchUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == login && x.RevokedOn != DateTime.MaxValue && x.RevokedBy != string.Empty);
            if (searchUser == null)
            {
                throw new KeyNotFoundException("User with this login(with RevokedOn and RevokedBy) not found");
            }
            searchUser.RevokedBy = string.Empty;
            searchUser.RevokedOn = DateTime.MaxValue;
            searchUser.ModifiedBy = name;
            searchUser.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return searchUser;


        }


        public string CheckUser(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            return jwtToken.Claims.FirstOrDefault(c => c.Type == "Guid").Value.ToString();
        }

        public async Task<UserModel> GetAvailableUser (string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.RevokedOn == DateTime.MaxValue);
        }



    }
}
