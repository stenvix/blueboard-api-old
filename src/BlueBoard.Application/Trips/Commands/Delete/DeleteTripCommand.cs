using MediatR;
using System;

namespace BlueBoard.Application.Trips.Commands.Delete
{
    public class DeleteTripCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTripCommand(Guid id)
        {
            Id = id;
        }
    }
}
