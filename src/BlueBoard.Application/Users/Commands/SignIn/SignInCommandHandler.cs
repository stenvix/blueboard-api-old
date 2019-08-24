using BlueBoard.Application.Users.Models;
using BlueBoard.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Users.Commands.SignIn
{
    public class SignInCommandHandler : BaseHandler<SignInCommand, AuthTokenModel>
    {
        public SignInCommandHandler(BlueBoardContext context, ILogger<BaseHandler<SignInCommand, AuthTokenModel>> logger) : base(context, logger)
        {
        }

        protected override Task<AuthTokenModel> Handle(SignInCommand request, BlueBoardContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(new AuthTokenModel());
        }
    }
}
