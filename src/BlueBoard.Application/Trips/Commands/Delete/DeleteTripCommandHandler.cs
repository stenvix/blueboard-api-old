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

namespace BlueBoard.Application.Trips.Commands.Delete
{
    public class DeleteTripCommandHandler : BaseHandler<DeleteTripCommand, Unit>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;

        public DeleteTripCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<DeleteTripCommand, Unit>> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
        }

        protected override async Task<Unit> Handle(DeleteTripCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var exists = await _tripRepository.ExistsAsync(request.Id);
            if (!exists) throw new NotFoundException(nameof(Trip), request.Id);
            var hasAccess = await _tripRepository.HasAccessAsync(request.Id, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            var entity = await _tripRepository.GetAsync(request.Id);
            entity.Status = TripStatus.Removed;
            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
