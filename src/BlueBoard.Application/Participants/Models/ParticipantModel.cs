using BlueBoard.Application.Common;
using BlueBoard.Common.Enums;

namespace BlueBoard.Application.Participants.Models
{
    public class ParticipantModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ParticipantRole Role { get; set; }
    }
}
