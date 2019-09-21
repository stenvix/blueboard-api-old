using MediatR;
using System;

namespace BlueBoard.Application.Participants.Commands.Remove
{
    public class RemoveParticipantCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
