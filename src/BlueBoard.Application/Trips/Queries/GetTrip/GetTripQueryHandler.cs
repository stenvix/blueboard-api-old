using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Trips.Models;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Trips.Queries.GetTrip
{
    public class GetTripQueryHandler : BaseHandler<GetTripQuery, TripModel>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;

        public GetTripQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetTripQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
        }

        protected override async Task<TripModel> Handle(GetTripQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var exists = await _tripRepository.ExistsAsync(request.Id);
            if (!exists) throw new NotFoundException(nameof(Trip), request.Id);

            var hasAccess = await _tripRepository.HasAccessAsync(request.Id, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            var entity = await _tripRepository.GetAsync(request.Id);
            return Mapper.Map<TripModel>(entity);
        }
    }
}
