using BlueBoard.Application.Common;
using FluentValidation;
using System;

namespace BlueBoard.Application.Participants.Commands.Add
{
    public class AddParticipantCommandValidator : AbstractValidator<AddParticipantCommand>
    {
        public AddParticipantCommandValidator()
        {
            this.ValidateEmail(i => i.Email);
            RuleFor(i => i.TripId)
                .NotEqual(Guid.Empty)
                .WithErrorCode(Codes.InvalidId);
        }
    }
}
