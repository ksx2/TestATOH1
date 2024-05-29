using TestATOH1.Models.AuthentificateModels;
using TestATOH1.Models.UserModels;

namespace TestATOH1.Models.Repository
{
    public interface IUserRepository
    {
        Task<string> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserGetByLoginResponseModel> GetByLogin(string login);

        Task<UserModel> GetByLoginAndPassword(string login,string password);

        Task<IEnumerable<UserModel>> GetOlderThanSmthAge(int old);

        Task<UserModel> Create(UserCreateRequestModel user);

        Task<UserModel> RemoveFull(string login);

        Task<UserModel> RemoveSoft(string login,string RevokedBy);

        Task<UserModel> UpdateUsernameGenderBirthday(string login, UserUpdateNameGenderBirthdayRequestModel user,string name);

        Task<string> UpdatePassword(string login, string password,string name);

        Task<string> UpdateLogin(string startLogin, string endLogin,string name);

        string CheckUser(string token);
        Task<UserModel> GetAvailableUser(string login);

        Task<UserModel> UpdateRevoked(string login,string name);


    }
}
