using AutoMapper;
using BlueBoard.Domain;

namespace BlueBoard.Application.Participants.Models
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<User, ParticipantModel>();
            CreateMap<User, ParticipantSearchModel>();

            CreateMap<Participant, ParticipantModel>()
                .ForMember(dest => dest.FirstName, src => src.MapFrom(i => i.User.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(i => i.User.LastName))
                .ForMember(dest => dest.Username, src => src.MapFrom(i => i.User.Username))
                .ForMember(dest => dest.Avatar, src => src.MapFrom(i => i.User.Avatar));
        }
    }
}
