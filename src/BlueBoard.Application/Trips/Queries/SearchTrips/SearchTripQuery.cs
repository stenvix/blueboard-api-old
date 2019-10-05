using BlueBoard.Application.Trips.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace BlueBoard.Application.Trips.Queries.SearchTrips
{
    public class SearchTripQuery : IRequest<IList<SlimTripModel>>
    {
        public string Query { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
