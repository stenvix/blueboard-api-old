using AutoMapper;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Trips.Commands.Create
{
    public class CreateTripCommandHandler : BaseHandler<CreateTripCommand, Guid>
    {
        #region Fields

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ITripRepository _tripRepository;
        private readonly ITripCountyRepository _tripCountryRepository;

        #endregion

        public CreateTripCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<CreateTripCommand, Guid>> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _tripRepository = unitOfWork.GetRepository<ITripRepository>();
            _tripCountryRepository = unitOfWork.GetRepository<ITripCountyRepository>();
        }

        protected override async Task<Guid> Handle(CreateTripCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var trip = new Trip
            {
                Name = request.Name.Trim(),
                Description = request.Description.Trim(),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CreatedById = _currentUserProvider.UserId
            };

            await _tripRepository.CreateAsync(trip);
            await unitOfWork.SaveChangesAsync();

            await _tripCountryRepository.CreateForTripAsync(trip.Id, request.Countries);
            await unitOfWork.SaveChangesAsync();

            return trip.Id;
        }

    }
}
