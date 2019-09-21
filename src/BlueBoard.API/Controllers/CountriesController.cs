using BlueBoard.Application.Countries.Models;
using BlueBoard.Application.Countries.Queries.GetCountries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    public class CountriesController : BaseController
    {
        public CountriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<CountryModel>), StatusCodes.Status200OK)]
        public Task<IList<CountryModel>> GetAllAsync()
            => Mediator.Send(new GetCountriesQuery());
    }
}
