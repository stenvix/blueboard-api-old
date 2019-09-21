using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
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
            var participant = await _participantRepository.GetAsync(request.Id);
            if (participant == null) throw new NotFoundException(nameof(Participant), request.Id);

            var hasAccess = await _tripRepository.HasAccessAsync(participant.TripId, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            await _participantRepository.DeleteAsync(request.Id);
            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
