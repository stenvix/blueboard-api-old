using System;

namespace BlueBoard.Domain
{
    /// <summary>
    /// Base interface for entities
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        Guid Id { get; set; }
    }
}
