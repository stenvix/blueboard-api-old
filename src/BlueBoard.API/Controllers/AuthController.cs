using BlueBoard.API.Models;
using BlueBoard.Application.Users.Commands.SignIn;
using BlueBoard.Application.Users.Commands.SignUp;
using BlueBoard.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator) { }

        [HttpPost("sign-in")]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthTokenModel), StatusCodes.Status200OK)]
        public Task<AuthTokenModel> SignIn([FromBody]SignInCommand command) => Mediator.Send(command);

        [HttpPost("sign-up")]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthTokenModel), StatusCodes.Status200OK)]
        public Task<AuthTokenModel> SignUp([FromBody]SignUpCommand command) => Mediator.Send(command);
    }
}
