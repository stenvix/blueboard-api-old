namespace BlueBoard.Common.Enums
{
    /// <summary>
    /// Participant status
    /// </summary>
    public enum ParticipantStatus
    {
        /// <summary>
        /// Nonparticipant
        /// </summary>
        Nonparticipant = 0,

        /// <summary>
        /// Invited participant (by owner)
        /// </summary>
        Invited = 1,

        /// <summary>
        /// Requested participant 
        /// </summary>
        Requested = 2,

        /// <summary>
        /// Approved participant
        /// </summary>
        Approved = 3,

        /// <summary>
        /// Declined participant
        /// </summary>
        Declined = 4
    }
}
