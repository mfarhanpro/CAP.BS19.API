using System.Collections.Generic;

namespace CAP.BS19.API.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
        public ICollection<City> City { get; set; }
    }
}