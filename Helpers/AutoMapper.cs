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
            CreateMap<UserCreateRequestModel, UserModel>().ForMember(dest => dest.Guid, opt => opt.MapFrom(src => Guid.NewGuid()))
                                                          .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => DateTime.MaxValue))
                                                          .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => string.Empty))
                                                          .ForMember(dest => dest.RevokedOn, opt => opt.MapFrom(src => DateTime.MaxValue))
                                                          .ForMember(dest => dest.RevokedBy, opt => opt.MapFrom(src => string.Empty));
            CreateMap<UserModel, AuthenticateResponse>();
            CreateMap<UserModel,UserGetByLoginResponseModel>();
            
        }
    }
}
