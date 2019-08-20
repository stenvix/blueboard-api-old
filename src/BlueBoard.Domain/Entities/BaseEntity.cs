﻿using System;

namespace BlueBoard.Domain
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        public Guid Id { get; set; }
    }
}
