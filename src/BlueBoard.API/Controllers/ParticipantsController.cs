using BlueBoard.Application.Participants.Commands.Approve;
using BlueBoard.Application.Participants.Commands.Decline;
using BlueBoard.Application.Participants.Commands.Invite;
using BlueBoard.Application.Participants.Commands.Remove;
using BlueBoard.Application.Participants.Commands.Request;
using BlueBoard.Application.Participants.Models;
using BlueBoard.Application.Participants.Queries.SearchParticipants;
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
        public ParticipantsController(IMediator mediator) : base(mediator) { }

        #region GET

        [HttpGet("search")]
        [ProducesResponseType(typeof(IList<ParticipantSearchModel>), StatusCodes.Status200OK)]
        public Task<IList<ParticipantSearchModel>> SearchParticipantAsync([FromQuery]string query, [FromQuery]Guid tripId)
            => Mediator.Send(new SearchParticipantQuery { TripId = tripId, Query = query });

        #endregion

        #region POST

        [HttpPost("invite")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public Task InviteParticipantAsync([FromBody] InviteParticipantCommand command)
            => Mediator.Send(command);

        [HttpPost("request")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public Task InviteParticipantAsync([FromBody] RequestParticipantCommand command)
            => Mediator.Send(command);

        [HttpPost("approve")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public Task ApproveParticipantAsync([FromBody] ApproveParticipantCommand command)
            => Mediator.Send(command);

        [HttpPost("decline")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public Task DeclineParticipantAsync([FromBody] DeclineParticipantCommand command)
            => Mediator.Send(command);

        [HttpPost("remove")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public Task RemoveParticipantAsync([FromBody] RemoveParticipantCommand command)
            => Mediator.Send(command);

        #endregion
    }
}
