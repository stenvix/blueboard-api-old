using AutoMapper;
using BlueBoard.Domain;

namespace BlueBoard.Application.Users.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, SlimUserModel>();
        }
    }
}
