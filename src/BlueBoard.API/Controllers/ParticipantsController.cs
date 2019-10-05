using BlueBoard.Application.Participants.Commands.Add;
using BlueBoard.Application.Participants.Commands.Remove;
using BlueBoard.Application.Participants.Queries.SearchParticipants;
using BlueBoard.Application.Users.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    public class ParticipantsController : BaseController
    {
        public ParticipantsController(IMediator mediator) : base(mediator)
        {
        }

        #region Get

        [HttpGet("search")]
        [ProducesResponseType(typeof(IList<SlimUserModel>), StatusCodes.Status200OK)]
        public Task<IList<SlimUserModel>> SearchParticipantAsync([FromQuery]string query)
            => Mediator.Send(new SearchParticipantQuery { Query = query });

        #endregion

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
