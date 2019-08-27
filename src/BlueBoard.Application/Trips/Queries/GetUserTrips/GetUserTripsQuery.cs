using BlueBoard.Application.Trips.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace BlueBoard.Application.Trips.Queries.GetUserTrips
{
    public class GetUserTripsQuery : IRequest<IList<TripSlimModel>>
    {
        public GetUserTripsQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; }
    }
}
