using System;

namespace BlueBoard.Application.Infrastructure
{
    public interface ICurrentUserProvider
    {
        Guid UserId { get; }
    }
}
