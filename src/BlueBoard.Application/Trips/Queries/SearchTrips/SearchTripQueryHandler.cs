using AutoMapper;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Trips.Models;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Trips.Queries.SearchTrips
{
    public class SearchTripQueryHandler : BaseHandler<SearchTripQuery, IList<SlimTripModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;

        public SearchTripQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SearchTripQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
        }

        protected override async Task<IList<SlimTripModel>> Handle(SearchTripQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            IList<Trip> entities;
            if (string.IsNullOrEmpty(request.Query) && !request.FromDate.HasValue && !request.ToDate.HasValue)
            {
                entities = await _tripRepository.GetForUserAsync(_currentUserProvider.UserId);
            }
            else
            {
                entities = await _tripRepository.SearchForUserAsync(_currentUserProvider.UserId, request.Query, request.FromDate, request.ToDate);
            }

            return Mapper.Map<IList<SlimTripModel>>(entities);
        }
    }
}
