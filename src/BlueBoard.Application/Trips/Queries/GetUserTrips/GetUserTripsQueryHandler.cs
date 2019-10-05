using AutoMapper;
using BlueBoard.Application.Trips.Models;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueBoard.Application.Infrastructure;

namespace BlueBoard.Application.Trips.Queries.GetUserTrips
{
    public class GetUserTripsQueryHandler : BaseHandler<GetUserTripsQuery, IList<SlimTripModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;

        public GetUserTripsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetUserTripsQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
        }

        protected override async Task<IList<SlimTripModel>> Handle(GetUserTripsQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var entities = await _tripRepository.GetForUserAsync(_currentUserProvider.UserId);
            return Mapper.Map<IList<SlimTripModel>>(entities);
        }
    }
}
