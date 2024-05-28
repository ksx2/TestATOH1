using AutoMapper;
using TestATOH1.Models.AuthentificateModels;
using TestATOH1.Models.UserModels;


// class to mapping incoming data to user's class(AutoMapper Nuget package)
namespace TestATOH1.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateRequestModel, UserModel>().ForMember("Guid",opt => Guid.NewGuid());
            CreateMap<UserModel, AuthenticateResponse>();
            CreateMap<UserModel,UserGetByLoginResponseModel>();
            
        }
    }
}
