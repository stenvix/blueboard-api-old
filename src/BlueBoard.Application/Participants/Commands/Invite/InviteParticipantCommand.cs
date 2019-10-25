using BlueBoard.Application.Participants.Commands.Base.Abstractions;
using BlueBoard.Common.Enums;
using MediatR;

namespace BlueBoard.Application.Participants.Commands.Invite
{
    public class InviteParticipantCommand : BaseParticipantCommand, IRequest
    {
        public ParticipantRole Role { get; set; } = ParticipantRole.Reader;
    }
}
