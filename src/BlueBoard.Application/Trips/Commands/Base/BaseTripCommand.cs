using System;
using System.Collections.Generic;
using MediatR;

namespace BlueBoard.Application.Trips.Commands.Base
{
    public class BaseTripCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<Guid> Countries { get; set; }
    }
}
