using BlueBoard.Application.Participants.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BlueBoard.Application.Participants.Commands.Remove;

namespace BlueBoard.API.Controllers
{
    public class ParticipantsController : BaseController
    {
        public ParticipantsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public Task<Guid> AddParticipantAsync([FromBody] AddParticipantCommand command)
            => Mediator.Send(command);

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task RemoveParticipantAsync([FromRoute] Guid id)
            => Mediator.Send(new RemoveParticipantCommand { Id = id });
    }
}
