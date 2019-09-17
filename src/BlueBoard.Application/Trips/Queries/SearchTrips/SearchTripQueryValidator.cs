using FluentValidation;

namespace BlueBoard.Application.Trips.Queries.SearchTrips
{
    public class SearchTripQueryValidator : AbstractValidator<SearchTripQuery>
    {
        public SearchTripQueryValidator()
        {
            RuleFor(i => i.ToDate)
                .GreaterThan(i => i.FromDate).WithErrorCode(Codes.InvalidToDate)
                .When(i => i.FromDate.HasValue && i.ToDate.HasValue);
        }
    }
}
