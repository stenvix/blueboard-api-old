using System;
using MediatR;

namespace BlueBoard.Application.Participants.Commands.Base.Abstractions
{
    public class BaseParticipantCommand : IRequest
    {
        public string Username { get; set; }
        public Guid TripId { get; set; }
    }
}
