using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Trips.Commands.Update
{
    public class UpdateTripCommandHandler : BaseHandler<UpdateTripCommand, Guid>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;
        private readonly ITripCountyRepository _tripCountryRepository;

        public UpdateTripCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<UpdateTripCommand, Guid>> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
            _tripCountryRepository = unitOfWork.GetRepository<ITripCountyRepository>();
        }

        protected override async Task<Guid> Handle(UpdateTripCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var exists = await _tripRepository.ExistsAsync(request.Id);
            if (!exists) throw new NotFoundException(nameof(Trip), request.Id);

            var hasAccess = await _tripRepository.HasAccessAsync(request.Id, _currentUserProvider.UserId);
            if (!hasAccess) throw new AuthException(Codes.HasNoPermissions);

            var entity = await _tripRepository.GetAsync(request.Id);
            Mapper.Map(request, entity);

            await _tripRepository.UpdateAsync(entity);
            await _tripCountryRepository.UpdateForTripAsync(request.Id, request.Countries);
            await unitOfWork.SaveChangesAsync();

            return request.Id;
        }
    }
}
