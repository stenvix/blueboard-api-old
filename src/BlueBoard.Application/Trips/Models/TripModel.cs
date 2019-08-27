using System.Collections.Generic;
using BlueBoard.Application.Common;
using BlueBoard.Application.Countries.Models;
using BlueBoard.Domain;

namespace BlueBoard.Application.Trips.Models
{
    public class TripModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<CountryModel> Countries { get; set; }
    }
}
