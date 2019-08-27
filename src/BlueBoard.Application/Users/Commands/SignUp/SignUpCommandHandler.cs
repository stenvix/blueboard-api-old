using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Models;
using BlueBoard.Common.Enums;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Users.Commands.SignUp
{
    public class SignUpCommandHandler : BaseHandler<SignUpCommand, AuthTokenModel>
    {
        #region Fields

        private readonly IUserRepository _userRepository;
        private readonly IAuthHandler _authHandler;

        #endregion

        public SignUpCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SignUpCommandHandler> logger, IAuthHandler authHandler) : base(unitOfWork, mapper, logger)
        {
            _authHandler = authHandler;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<AuthTokenModel> Handle(SignUpCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var existed = await _userRepository.GetByEmailAsync(request.Email);
            if (existed != null) throw new ValidationException(Codes.EmailInUse);
            var passwordHash = _authHandler.GetPasswordHash(request.Password);
            var user = new User { Email = request.Email, Password = passwordHash, Status = UserStatus.Verified };
            await _userRepository.CreateAsync(user);
            await unitOfWork.SaveChangesAsync();
            return _authHandler.CreateAuthToken(user.Id);
        }
    }
}
