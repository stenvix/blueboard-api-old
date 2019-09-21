using AutoMapper;
using BlueBoard.Domain;

namespace BlueBoard.Application.Participants.Models
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<Participant, ParticipantModel>()
                .ForMember(dest => dest.FirstName, src => src.MapFrom(i => i.User.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(i => i.User.LastName));
        }
    }
}
