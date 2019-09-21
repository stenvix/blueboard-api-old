using FluentValidation;
using System;

namespace BlueBoard.Application.Participants.Queries.GetTripParticipants
{
    public class GetTripParticipantQueryValidator : AbstractValidator<GetTripParticipantQuery>
    {
        public GetTripParticipantQueryValidator()
        {
            RuleFor(i => i.TripId)
                .NotEqual(i => Guid.Empty)
                .WithErrorCode(Codes.InvalidId);
        }
    }
}
