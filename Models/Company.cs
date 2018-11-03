using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAP.BS19.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTime EntryTime { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public ICollection<Office> Office { get; set; }
    }
}