using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAP.BS19.API.Models
{
    public class Retailer
    {
        public int RetailerId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime EntryTime { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? OfficeId { get; set; }
        public Office Office { get; set; }
        public int? RegionId { get; set; }
        public Region Region { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
    }
}