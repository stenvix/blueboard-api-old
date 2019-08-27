using AutoMapper;
using BlueBoard.Domain;
using System.Linq;
using BlueBoard.Application.Trips.Commands.Update;

namespace BlueBoard.Application.Trips.Models
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripSlimModel>()
                .ForMember(dest => dest.Countries, src => src.MapFrom(i => string.Join(", ", i.Countries.Select(c => c.Country.Name))));
            CreateMap<Trip, TripModel>();

            CreateMap<UpdateTripCommand, Trip>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.Participants, src => src.Ignore())
                .ForMember(dest => dest.Countries, src => src.Ignore());
        }

    }
}
