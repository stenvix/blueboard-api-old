using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Commands.Invite
{
    public class InviteParticipantCommandHandler : BaseHandler<InviteParticipantCommand, Guid>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IUserRepository _userRepository;

        public InviteParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<InviteParticipantCommandHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
            _participantRepository = unitOfWork.GetRepository<IParticipantRepository>();
        }

        protected override async Task<Guid> Handle(InviteParticipantCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var hasAccess = await _tripRepository.HasAccessAsync(request.TripId, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null) throw new ValidationException(Codes.InvalidUsername);
            if (user.Id == _currentUserProvider.UserId) throw new ValidationException(Codes.InvalidOperation);

            var exists = await _participantRepository.ExistsAsync(user.Id, request.TripId);
            if (exists) throw new ValidationException(Codes.AlreadyExists);

            var entity = new Participant { TripId = request.TripId, UserId = user.Id, Role = request.Role };
            await _participantRepository.CreateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return entity.Id;
        }
    }
}
