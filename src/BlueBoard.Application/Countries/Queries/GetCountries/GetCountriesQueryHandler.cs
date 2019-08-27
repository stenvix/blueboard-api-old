using AutoMapper;
using BlueBoard.Application.Countries.Models;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Countries.Queries.GetCountries
{
    public class GetCountriesQueryHandler : BaseHandler<GetCountriesQuery, IList<CountryModel>>
    {
        private readonly ICountryRepository _countryRepository;

        public GetCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<GetCountriesQuery, IList<CountryModel>>> logger) : base(unitOfWork, mapper, logger)
        {
            _countryRepository = unitOfWork.GetRepository<ICountryRepository>();
        }

        protected override async Task<IList<CountryModel>> Handle(GetCountriesQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var entities = await _countryRepository.GetAllAsync();
            return Mapper.Map<IList<CountryModel>>(entities);
        }
    }
}
