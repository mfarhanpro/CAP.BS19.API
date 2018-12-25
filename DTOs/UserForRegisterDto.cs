using System;
using System.ComponentModel.DataAnnotations;

namespace CAP.BS19.API.DTOs
{
    public class UserForRegisterDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LoginUserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime EntryTime { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "You must specify password between 3 to 12 characters")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CompanyId { get; set; }
        public int? OfficeId { get; set; }
        public int? UserRoleId { get; set; }
    }
}