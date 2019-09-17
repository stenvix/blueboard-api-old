using BlueBoard.Application.Trips.Models;
using MediatR;
using System.Collections.Generic;

namespace BlueBoard.Application.Trips.Queries.GetUserTrips
{
    public class GetUserTripsQuery : IRequest<IList<TripSlimModel>>
    {
    }
}
