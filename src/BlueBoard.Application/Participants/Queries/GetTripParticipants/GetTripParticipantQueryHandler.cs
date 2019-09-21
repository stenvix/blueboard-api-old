using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Participants.Models;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Queries.GetTripParticipants
{
    public class GetTripParticipantQueryHandler : BaseHandler<GetTripParticipantQuery, IList<ParticipantModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IParticipantRepository _participantRepository;
        private readonly ITripRepository _tripRepository;

        public GetTripParticipantQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetTripParticipantQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _participantRepository = unitOfWork.GetRepository<IParticipantRepository>();
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
        }

        protected override async Task<IList<ParticipantModel>> Handle(GetTripParticipantQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var exists = await _tripRepository.ExistsAsync(request.TripId);
            if (!exists) throw new NotFoundException(nameof(Trip), request.TripId);

            var hasAccess = await _tripRepository.HasAccessAsync(request.TripId, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            var entities = await _participantRepository.GetForTripAsync(request.TripId);
            return Mapper.Map<IList<ParticipantModel>>(entities);
        }
    }
}
