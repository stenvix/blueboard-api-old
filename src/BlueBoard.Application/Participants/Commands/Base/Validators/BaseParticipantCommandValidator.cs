using BlueBoard.Application.Users.Base;
using FluentValidation;
using System;
using BlueBoard.Application.Participants.Commands.Base.Abstractions;

namespace BlueBoard.Application.Participants.Commands.Base.Validators
{
    public abstract class BaseParticipantCommandValidator<TRequest> : AbstractValidator<TRequest> where TRequest : BaseParticipantCommand
    {
        protected BaseParticipantCommandValidator()
        {
            RuleFor(i => i.Username)
                .NotEmpty().WithErrorCode(Codes.EmptyUsername)
                .SetValidator(new UsernameValidator());

            RuleFor(i => i.TripId)
                .NotEqual(Guid.Empty).WithErrorCode(Codes.InvalidId);
        }
    }
}
