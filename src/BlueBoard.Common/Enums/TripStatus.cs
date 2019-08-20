namespace BlueBoard.Common.Enums
{
    /// <summary>
    /// Status of trip
    /// </summary>
    public enum TripStatus
    {
        /// <summary>
        /// Future trip
        /// </summary>
        Future,

        /// <summary>
        /// Currently in process
        /// </summary>
        Current,

        //Archived trip
        Archived,

        /// <summary>
        /// Canceled trip
        /// </summary>
        Canceled,

        /// <summary>
        /// Removed trip
        /// </summary>
        Removed
    }
}