using BlueBoard.Application.Participants.Models;
using BlueBoard.Application.Participants.Queries.GetTripParticipants;
using BlueBoard.Application.Trips.Commands.Create;
using BlueBoard.Application.Trips.Commands.Delete;
using BlueBoard.Application.Trips.Commands.Update;
using BlueBoard.Application.Trips.Models;
using BlueBoard.Application.Trips.Queries.GetTrip;
using BlueBoard.Application.Trips.Queries.GetUserTrips;
using BlueBoard.Application.Trips.Queries.SearchTrips;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.API.Controllers
{
    public class TripsController : BaseController
    {
        public TripsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<SlimTripModel>), StatusCodes.Status200OK)]
        public Task<IList<SlimTripModel>> GetUserTripsAsync()
            => Mediator.Send(new GetUserTripsQuery());

        [HttpGet("{id}")]
        public Task<TripModel> GetTripAsync(Guid id)
            => Mediator.Send(new GetTripQuery(id));

        [HttpGet("search")]
        [ProducesResponseType(typeof(IList<SlimTripModel>), StatusCodes.Status200OK)]
        public Task<IList<SlimTripModel>> SearchTripsAsync([FromQuery]string query, [FromQuery]DateTime? fromDate, [FromQuery]DateTime? toDate)
            => Mediator.Send(new SearchTripQuery { Query = query, FromDate = fromDate, ToDate = toDate });

        [HttpGet("{id}/participants")]
        [ProducesResponseType(typeof(IList<ParticipantModel>), StatusCodes.Status200OK)]
        public Task<IList<ParticipantModel>> GetTripParticipantsAsync([FromRoute] Guid id)
            => Mediator.Send(new GetTripParticipantQuery { TripId = id });

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public Task<Guid> CreateTripAsync([FromBody] CreateTripCommand command)
            => Mediator.Send(command);

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public Task<Guid> UpdateTripAsync([FromBody] UpdateTripCommand command)
            => Mediator.Send(command);

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task DeleteTripAsync([FromRoute] Guid id)
            => Mediator.Send(new DeleteTripCommand(id));
    }
}
