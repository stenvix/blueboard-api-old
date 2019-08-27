using BlueBoard.Application.Common;
using BlueBoard.Application.Trips.Models;
using MediatR;
using System;

namespace BlueBoard.Application.Trips.Queries.GetTrip
{
    public class GetTripQuery : BaseGetQuery, IRequest<TripModel>
    {
        public GetTripQuery(Guid id) : base(id)
        {
        }
    }
}
