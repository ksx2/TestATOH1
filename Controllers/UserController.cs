using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestATOH1.Helpers;
using TestATOH1.Models.AuthentificateModels;
using TestATOH1.Models.Repository;
using TestATOH1.Models.UserModels;

namespace TestATOH1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly AppSettings _appSettings;
        //public AuthenticateRequest authenticate;

        public UserController(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _repository = userRepository;
            _appSettings = appSettings.Value;
        }

        //AUTH
        [HttpPost("authenticate")]
        public string Authenticate(AuthenticateRequest model)
        {
            var response = _repository.Authenticate(model);
            return response.Result;
        }

        //CREATE
        //1.Создание пользователя по логину, паролю, имени, полу и дате рождения
        //+ указание будет ли пользователь админом(Доступно Админам)
        [Authorize()]
        [HttpPost("create")]
        public async Task<UserModel> Create(UserCreateRequestModel userCreate)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.Create(userCreate);
                return result;
            }
            else
            {
                throw new AppException("The data from the request was unsuccessfully linked");
            }

        }

        //UPDATE-1
        //2) Изменение имени, пола или даты рождения пользователя(Может менять Администратор, либо
        //лично пользователь, если он активен (отсутствует RevokedOn))
        [Authorize]
        [HttpPut("update/additional")]

        public async Task<UserModel> UpdateNameGenderBirthday ([FromQuery] string login, [FromBody] UserUpdateNameGenderBirthdayRequestModel userModel)
        {
            if (User.IsInRole("admin"))
            {
                return await _repository.UpdateUsernameGenderBirthday(login,userModel);
            }
            else
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var guidFromClaims = _repository.CheckUser(token);
                var user = await _repository.GetAvailableUser(login);
                if (guidFromClaims != user.Guid.ToString())
                {
                    throw new AppException("Available only to the user himself");
                }
                return await _repository.UpdateUsernameGenderBirthday(login, userModel);
            }
        }
        //3) Изменение пароля(Пароль может менять либо Администратор, либо лично пользователь, если
        //он активен (отсутствует RevokedOn))
        [Authorize]
        [HttpPut("update/password")]
        public async Task<string> UpdatePassword ([FromQuery] string login, [FromBody] string password )
        {
            if (User.IsInRole("admin"))
            {
                return await _repository.UpdatePassword(login,password);
            }
            else
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var guidFromClaims = _repository.CheckUser(token);
                var user = await _repository.GetAvailableUser(login);
                if (guidFromClaims != user.Guid.ToString())
                {
                    throw new AppException("Available only to the user himself");
                }
                return await _repository.UpdatePassword(login, password);
            }
        }

        //4) Изменение логина(Логин может менять либо Администратор, либо лично пользователь, если
        //он активен (отсутствует RevokedOn), логин должен оставаться уникальным)
        [Authorize]
        [HttpPut("update/login")]
        public async Task<string> UpdateLogin([FromQuery]string startLogin, [FromBody] string endLogin)
        {
            if (User.IsInRole("admin"))
            {
                return await _repository.UpdateLogin(startLogin,endLogin);
            }
            else
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var guidFromClaims = _repository.CheckUser(token);
                var user = await _repository.GetAvailableUser(startLogin);
                if (guidFromClaims != user.Guid.ToString())
                {
                    throw new AppException("Available only to the user himself");
                }
                return await _repository.UpdateLogin(startLogin, endLogin);
            }
        }


        //READ
        //5.Запрос списка всех активных(отсутствует RevokedOn) пользователей,
        //список отсортирован по CreatedOn(Доступно Админам)
        [Authorize(Roles = "admin")]
        [HttpGet("get/all"),Authorize]
        public async Task<IEnumerable<UserModel>> GetAll()
        {
               
               return await _repository.GetAll();
            
        }
        
        //6.Запрос пользователя по логину, в списке долны быть имя, пол и дата рождения статус активный
        //или нет(Доступно Админам)
        [Authorize(Roles = "admin")]
        [HttpGet("get/login")]
        public async Task<UserGetByLoginResponseModel> GetByLogin([FromQuery] string login)
        {

            return await _repository.GetByLogin(login);
            
        }

        //7.Запрос пользователя по логину и паролю(Доступно только самому пользователю, если он
        //активен (отсутствует RevokedOn))
        [Authorize]
        [HttpGet("get/login/password")]
        public async Task<UserModel> GetByLoginAndPassword([FromQuery] string login, [FromBody] string password)
        {
            
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var guidFromClaims = _repository.CheckUser(token);
            var user = await _repository.GetByLoginAndPassword(login,password);
            if (guidFromClaims != user.Guid.ToString())
            {
                throw new AppException("Available only to the user himself");
            }
            return user;
        }
        //8.Запрос всех пользователей старше определённого возраста (Доступно Админам)
        [Authorize(Roles = "admin")]
        [HttpGet("get/age")]
        public async Task<IEnumerable<UserModel>> GetOlderThanSmthAge([FromQuery]int old)
        {
           return await _repository.GetOlderThanSmthAge(old);
        }

        //DELETE
        //9) Удаление пользователя по логину полное или мягкое(При мягком удалении должна
        // происходить простановка RevokedOn и RevokedBy) (Доступно Админам)
        [Authorize(Roles = "admin")]
        [HttpDelete("remove/login")]
        public async Task<UserModel> RemoveSoftOrFull([FromBody] string login, bool soft)
        {
            if(soft == true)
            {
                return await _repository.RemoveSoft(login, User.Identity.Name);
            }
            return await _repository.RemoveFull(login);
        }

        //UPDATE-2
        //10.Восстановление пользователя - Очистка полей(RevokedOn, RevokedBy) (Доступно Админам)
        [Authorize(Roles = "admin")]
        [HttpPut("update/login/revoke")]
        public async Task<UserModel> UpdateRevoke([FromBody] string login)
        {
            return await _repository.UpdateRevoked(login);
        }
    }
}
