using FluentValidation;
using System;

namespace BlueBoard.Application.Trips.Queries.GetUserTrips
{
    public class GetUserTripsQueryValidator : AbstractValidator<GetUserTripsQuery>
    {
        public GetUserTripsQueryValidator()
        {
            RuleFor(i => i.UserId).Must(i => i != Guid.Empty);
        }
    }
}
