using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Common.Enums;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Users.Commands.Setup
{
    public class SetupUserCommandHandler : BaseHandler<SetupUserCommand, Guid>
    {
        #region Fields

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserRepository _userRepository;

        #endregion

        public SetupUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<SetupUserCommand, Guid>> logger, ICurrentUserProvider currentUserProvider, IAuthHandler authHandler) : base(unitOfWork, mapper, logger)
        {
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
            _currentUserProvider = currentUserProvider;
        }

        protected override async Task<Guid> Handle(SetupUserCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetAsync(_currentUserProvider.UserId);
            if (entity == null) throw new NotFoundException(nameof(User), _currentUserProvider.UserId);
            if (entity.Status != UserStatus.Initial) throw new ValidationException(Codes.InvalidOperation);

            Mapper.Map(request, entity);
            entity.Status = UserStatus.Verified;

            await _userRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();

            return entity.Id;
        }
    }
}
