using BlueBoard.Application.Users.Models;
using BlueBoard.Common.Enums;

namespace BlueBoard.Application.Participants.Models
{
    public class ParticipantBaseModel : UserSlimModel
    {
        public ParticipantStatus Status { get; set; }
    }
}
