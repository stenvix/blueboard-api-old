using System;

namespace BlueBoard.Domain
{
    /// <summary>
    /// Trip to Country entity
    /// </summary>
    public class TripCountry
    {
        public Guid TripId { get; set; }
        public Guid CountryId { get; set; }

        public Trip Trip { get; set; }
        public Country Country { get; set; }
    }
}
