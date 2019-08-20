using System;
using System.Collections.Generic;
using BlueBoard.Common.Enums;

namespace BlueBoard.Domain
{
    /// <summary>
    /// Trip entity
    /// </summary>
    public class Trip : BaseEntity
    {
        /// <summary>
        /// Gets or sets trip name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets trip description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets start date of trip
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets end date of trip
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets trip status
        /// </summary>
        public TripStatus Status { get; set; }

        /// <summary>
        /// Gets or sets trip countries
        /// </summary>
        public ICollection<TripCountry> Countries { get; set; }

        /// <summary>
        /// Gets or sets trip participants
        /// </summary>
        public ICollection<Participant> Participants { get; set; }
    }
}
