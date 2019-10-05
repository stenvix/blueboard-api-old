using BlueBoard.Application.Users.Base;
using FluentValidation;
using System;

namespace BlueBoard.Application.Participants.Commands.Invite
{
    public class InviteParticipantCommandValidator : AbstractValidator<InviteParticipantCommand>
    {
        public InviteParticipantCommandValidator()
        {
            RuleFor(i => i.Username)
                .NotEmpty().WithErrorCode(Codes.EmptyUsername)
                .SetValidator(new UsernameValidator());

            RuleFor(i => i.TripId)
                .NotEqual(Guid.Empty)
                .WithErrorCode(Codes.InvalidId);
        }
    }
}
