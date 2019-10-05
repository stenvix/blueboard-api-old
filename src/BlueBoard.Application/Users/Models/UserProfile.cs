using AutoMapper;
using BlueBoard.Application.Users.Commands.Setup;
using BlueBoard.Application.Users.Commands.Update;
using BlueBoard.Domain;

namespace BlueBoard.Application.Users.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, SlimUserModel>();
            CreateMap<User, UserModel>();
            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.Password, src => src.Ignore())
                .ForMember(dest => dest.Email, src => src.Condition(i => !string.IsNullOrEmpty(i.Email)))
                .ForMember(dest => dest.Phone, src => src.Condition(i => !string.IsNullOrEmpty(i.Phone)));

            CreateMap<SetupUserCommand, User>();
        }
    }
}
