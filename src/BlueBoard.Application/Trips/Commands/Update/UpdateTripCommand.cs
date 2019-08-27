using BlueBoard.Application.Trips.Commands.Base;
using System;

namespace BlueBoard.Application.Trips.Commands.Update
{
    public class UpdateTripCommand : BaseTripCommand
    {
        public Guid Id { get; set; }
    }
}
