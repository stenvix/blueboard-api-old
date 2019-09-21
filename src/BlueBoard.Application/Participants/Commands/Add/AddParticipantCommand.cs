using BlueBoard.Common.Enums;
using MediatR;
using System;

namespace BlueBoard.Application.Participants.Commands.Add
{
    public class AddParticipantCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public Guid TripId { get; set; }
        public ParticipantRole Role { get; set; } = ParticipantRole.Reader;
    }
}
