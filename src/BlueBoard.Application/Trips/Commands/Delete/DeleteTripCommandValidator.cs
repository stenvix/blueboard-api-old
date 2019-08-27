using FluentValidation;
using System;

namespace BlueBoard.Application.Trips.Commands.Delete
{
    public class DeleteTripCommandValidator : AbstractValidator<DeleteTripCommand>
    {
        public DeleteTripCommandValidator()
        {
            RuleFor(i => i.Id).Must(i => i != Guid.Empty).WithErrorCode(Codes.InvalidId);
        }
    }
}
