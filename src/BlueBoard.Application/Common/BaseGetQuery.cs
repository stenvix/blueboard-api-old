using System;

namespace BlueBoard.Application.Common
{
    public class BaseGetQuery
    {
        public Guid Id { get; }

        public BaseGetQuery(Guid id)
        {
            Id = id;
        }
    }
}
