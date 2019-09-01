using FluentValidation;
using System;

namespace BlueBoard.Application.Trips.Commands.Base
{
    public class BaseTripCommandValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseTripCommand
    {
        public BaseTripCommandValidator()
        {
            RuleFor(i => i.StartDate).GreaterThanOrEqualTo(DateTime.UtcNow).WithErrorCode(Codes.InvalidStartDate);
            RuleFor(i => i.EndDate).GreaterThan(i => i.StartDate).WithErrorCode(Codes.InvalidEndDate);
            RuleFor(i => i.Countries).Must(i => i.Count > 0).WithErrorCode(Codes.EmptyCountry);
        }
    }
}
