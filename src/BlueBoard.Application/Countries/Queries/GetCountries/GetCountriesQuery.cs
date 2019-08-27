using System.Collections.Generic;
using BlueBoard.Application.Countries.Models;
using MediatR;

namespace BlueBoard.Application.Countries.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<IList<CountryModel>>
    {
    }
}
