using FluentValidation;
using System;

namespace BlueBoard.Application.Participants.Queries.SearchParticipants
{
    public class SearchParticipantQueryValidator : AbstractValidator<SearchParticipantQuery>
    {
        public SearchParticipantQueryValidator()
        {
            RuleFor(i => i.Query)
                .NotEmpty()
                .WithErrorCode(Codes.InvalidQuery);

            RuleFor(i => i.TripId)
                .NotEqual(Guid.Empty)
                .WithErrorCode(Codes.EmptyTripId);
        }
    }
}
