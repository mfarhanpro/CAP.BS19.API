using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAP.BS19.API.Models
{
    public class Office
    {
        public int OfficeId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string IsActive { get; set; }
        public DateTime EntryTime { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}