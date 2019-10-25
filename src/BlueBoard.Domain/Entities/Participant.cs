using System;
using BlueBoard.Common.Enums;

namespace BlueBoard.Domain
{
    /// <summary>
    /// Participant entity
    /// </summary>
    public class Participant : BaseEntity
    {
        public ParticipantRole Role { get; set; }
        public ParticipantStatus Status { get; set; }


        public Guid UserId { get; set; }
        public Guid TripId { get; set; }

        public User User { get; set; }
        public Trip Trip { get; set; }
    }
}
