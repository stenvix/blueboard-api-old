using BlueBoard.Application.Trips.Commands.Base;
using FluentValidation;
using System;

namespace BlueBoard.Application.Trips.Commands.Update
{
    public class UpdateTripCommandValidator : BaseTripCommandValidator<UpdateTripCommand>
    {
        public UpdateTripCommandValidator()
        {
            RuleFor(i => i.Id).Must(i => i != Guid.Empty).WithErrorCode(Codes.InvalidId);
        }
    }
}
