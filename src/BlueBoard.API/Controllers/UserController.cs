using System.Net;
using System.Threading.Tasks;
using BlueBoard.Application.Users.Commands.SignIn;
using BlueBoard.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlueBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthTokenModel), (int)HttpStatusCode.OK)]
        public Task<AuthTokenModel> SignIn([FromBody]SignInCommand command) => _mediator.Send(command);
    }
}
