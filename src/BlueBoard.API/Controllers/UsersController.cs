using BlueBoard.API.Models;
using BlueBoard.Application.Users.Commands.SignIn;
using BlueBoard.Application.Users.Commands.SignUp;
using BlueBoard.Application.Users.Models;
using BlueBoard.Application.Users.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class UsersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UsersController"/>
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthTokenModel), StatusCodes.Status200OK)]
        public Task<AuthTokenModel> SignIn([FromBody]SignInCommand command) => Mediator.Send(command);

        [AllowAnonymous]
        [HttpPost("sign-up")]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthTokenModel), StatusCodes.Status200OK)]
        public Task<AuthTokenModel> SignUp([FromBody]SignUpCommand command) => Mediator.Send(command);

        [HttpGet("/api/v1/me")]
        [ProducesResponseType(typeof(SlimUserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        public Task<SlimUserModel> GetCurrentUserAsync() => Mediator.Send(new GetCurrentUserQuery());
    }
}
