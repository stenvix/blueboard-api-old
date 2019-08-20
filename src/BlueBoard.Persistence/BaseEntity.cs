using System;

namespace BlueBoard.Persistence
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        public Guid Id { get; set; }
    }
}
