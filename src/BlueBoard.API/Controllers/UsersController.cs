using BlueBoard.API.Models;
using BlueBoard.Application.Users.Commands.Setup;
using BlueBoard.Application.Users.Commands.Update;
using BlueBoard.Application.Users.Models;
using BlueBoard.Application.Users.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    public class UsersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UsersController"/>
        /// </summary>
        /// <param name="mediator">Mediator</param>
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("/api/v1/Me")]
        [ProducesResponseType(typeof(SlimUserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        public Task<UserModel> GetCurrentUserAsync()
            => Mediator.Send(new GetCurrentUserQuery());

        [HttpPut("/api/v1/Me")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        public Task UpdateCurrentUserAsync([FromBody] UpdateUserCommand command)
            => Mediator.Send(command);

        [HttpPut("/api/v1/Me/Setup")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        public Task InitialSetupAsync([FromBody] SetupUserCommand command)
            => Mediator.Send(command);
    }
}
