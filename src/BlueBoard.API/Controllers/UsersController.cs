using BlueBoard.API.Models;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Commands.SignIn;
using BlueBoard.Application.Users.Commands.SignUp;
using BlueBoard.Application.Users.Commands.Update;
using BlueBoard.Application.Users.Models;
using BlueBoard.Application.Users.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class UsersController : BaseController
    {
        private readonly ICurrentUserProvider _currentUserProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="UsersController"/>
        /// </summary>
        /// <param name="mediator">Mediator</param>
        /// <param name="currentUserProvider">Current user provider</param>
        public UsersController(IMediator mediator, ICurrentUserProvider currentUserProvider) : base(mediator)
        {
            _currentUserProvider = currentUserProvider;
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

        [HttpPut("/api/v1/me")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionModel), StatusCodes.Status400BadRequest)]
        public Task<Guid> UpdateCurrentUserAsync([FromBody] UpdateUserCommand command)
        {
            command.Id = _currentUserProvider.UserId;
            return Mediator.Send(command);
        }
    }
}
