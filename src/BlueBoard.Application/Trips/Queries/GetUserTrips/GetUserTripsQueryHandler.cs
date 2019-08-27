using AutoMapper;
using BlueBoard.Application.Trips.Models;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Trips.Queries.GetUserTrips
{
    public class GetUserTripsQueryHandler : BaseHandler<GetUserTripsQuery, IList<TripSlimModel>>
    {
        private readonly ITripRepository _tripRepository;

        public GetUserTripsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetUserTripsQueryHandler> logger) : base(unitOfWork, mapper, logger)
        {
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
        }

        protected override async Task<IList<TripSlimModel>> Handle(GetUserTripsQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var entities = await _tripRepository.GetForUserAsync(request.UserId);
            return Mapper.Map<IList<TripSlimModel>>(entities);
        }
    }
}
