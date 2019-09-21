using BlueBoard.Application.Participants.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace BlueBoard.Application.Participants.Queries.GetTripParticipants
{
    public class GetTripParticipantQuery : IRequest<IList<ParticipantModel>>
    {
        public Guid TripId { get; set; }
    }
}
