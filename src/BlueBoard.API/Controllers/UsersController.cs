using BlueBoard.Application.Users.Commands.SignIn;
using BlueBoard.Application.Users.Commands.SignUp;
using BlueBoard.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AuthTokenModel), (int)HttpStatusCode.OK)]
        public Task<AuthTokenModel> SignIn([FromBody]SignInCommand command) => Mediator.Send(command);

        [AllowAnonymous]
        [HttpPost("sign-up")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AuthTokenModel), (int)HttpStatusCode.OK)]
        public Task<AuthTokenModel> SignUp([FromBody]SignUpCommand command) => Mediator.Send(command);
    }
}
