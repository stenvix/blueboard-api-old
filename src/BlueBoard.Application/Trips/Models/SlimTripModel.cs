using BlueBoard.Application.Common;

namespace BlueBoard.Application.Trips.Models
{
    public class SlimTripModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Countries { get; set; }
    }
}
