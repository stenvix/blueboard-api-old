using AutoMapper;
using BlueBoard.Domain;

namespace BlueBoard.Application.Countries.Models
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryModel>();
            CreateMap<TripCountry, CountryModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(i => i.Country.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(i => i.Country.Name))
                .ForMember(dest => dest.Iso, src => src.MapFrom(i => i.Country.Iso));
        }
    }
}
