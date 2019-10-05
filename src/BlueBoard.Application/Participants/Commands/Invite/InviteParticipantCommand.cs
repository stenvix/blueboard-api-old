using BlueBoard.Common.Enums;
using MediatR;
using System;

namespace BlueBoard.Application.Participants.Commands.Invite
{
    public class InviteParticipantCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public Guid TripId { get; set; }
        public ParticipantRole Role { get; set; } = ParticipantRole.Reader;
    }
}
