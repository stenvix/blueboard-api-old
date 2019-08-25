using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Models;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Users.Commands.SignIn
{
    public class SignInCommandHandler : BaseHandler<SignInCommand, AuthTokenModel>
    {
        #region Fields

        private readonly IAuthHandler _authHandler;
        private readonly IUserRepository _userRepository;

        #endregion

        public SignInCommandHandler(IUnitOfWork unitOfWork, ILogger<BaseHandler<SignInCommand, AuthTokenModel>> logger, IAuthHandler authHandler) : base(unitOfWork, logger)
        {
            _authHandler = authHandler;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<AuthTokenModel> Handle(SignInCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) throw new NotFoundException("User", request.Email);

            if (!_authHandler.ValidatePassword(request.Password, user.Password)) throw new AuthException(Codes.InvalidCredentials);

            return _authHandler.CreateAuthToken(user.Id);
        }
    }
}
