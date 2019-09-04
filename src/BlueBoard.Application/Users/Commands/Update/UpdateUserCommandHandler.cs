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

namespace BlueBoard.Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : BaseHandler<UpdateUserCommand, Guid>
    {
        #region Fields

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IAuthHandler _authHandler;
        private readonly IUserRepository _userRepository;

        #endregion

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserCommandHandler> logger, ICurrentUserProvider currentUserProvider, IAuthHandler authHandler) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _authHandler = authHandler;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<Guid> Handle(UpdateUserCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetAsync(_currentUserProvider.UserId);
            if (entity == null) throw new NotFoundException(nameof(User), _currentUserProvider.UserId);
            if (entity.Status != UserStatus.Verified) throw new ValidationException(Codes.InvalidOperation);

            Mapper.Map(request, entity);
            if (!string.IsNullOrEmpty(request.Password))
            {
                entity.Password = _authHandler.GetPasswordHash(entity.Password);
            }

            await _userRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();

            return _currentUserProvider.UserId;
        }
    }
}
