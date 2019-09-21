using FluentValidation;
using System;

namespace BlueBoard.Application.Participants.Commands.Remove
{
    public class RemoveParticipantCommandValidator : AbstractValidator<RemoveParticipantCommand>
    {
        public RemoveParticipantCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEqual(Guid.Empty)
                .WithErrorCode(Codes.InvalidId);
        }
    }
}
