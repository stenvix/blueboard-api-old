using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Common.Enums;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Commands.Remove
{
    public class RemoveParticipantCommandHandler : BaseHandler<RemoveParticipantCommand, Unit>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;
        private readonly IParticipantRepository _participantRepository;

        public RemoveParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RemoveParticipantCommandHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
            _participantRepository = unitOfWork.GetRepository<IParticipantRepository>();
        }

        protected override async Task<Unit> Handle(RemoveParticipantCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var hasAccess = await _tripRepository.HasAccessAsync(request.TripId, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            var participant = await _participantRepository.GetForTripAsync(request.TripId, request.Username);
            if (participant == null) throw new NotFoundException(nameof(Participant), request.Username);

            if (participant.Status == ParticipantStatus.Approved) throw new ValidationException(Codes.InvalidOperation);

            await _participantRepository.DeleteAsync(participant.Id);
            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
