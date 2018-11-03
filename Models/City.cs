using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAP.BS19.API.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        public string IsActive { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}