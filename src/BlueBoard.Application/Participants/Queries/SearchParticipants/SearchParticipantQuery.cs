using BlueBoard.Application.Participants.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace BlueBoard.Application.Participants.Queries.SearchParticipants
{
    public class SearchParticipantQuery : IRequest<IList<ParticipantSearchModel>>
    {
        public Guid TripId { get; set; }
        public string Query { get; set; }
    }
}
