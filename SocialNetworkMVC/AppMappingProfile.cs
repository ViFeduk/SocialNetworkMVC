using AutoMapper;
using SocialNetworkMVC.Models;
using SocialNetworkMVC.Views.ViewsModels;

namespace SocialNetworkMVC
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.DateBirth, opt => opt.MapFrom(src => new DateTime(int.Parse(src.Year), int.Parse(src.Month), int.Parse(src.Day))))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailReg))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.EmailReg));

            CreateMap<LoginViewModels, User>()
                 .ForMember(dest => dest.FirstName, opt => opt.Ignore()) 
            .ForMember(dest => dest.MidleName, opt => opt.Ignore())
            .ForMember(dest => dest.LastName, opt => opt.Ignore())
            .ForMember(dest => dest.DateBirth, opt => opt.Ignore());

            CreateMap<User, UserWithFriendExt>()
             .ForMember(dest => dest.IsFriendWithCurrent, opt => opt.MapFrom(src => false));
        }
    }
}
