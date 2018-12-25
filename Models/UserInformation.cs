using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAP.BS19.API.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LoginUserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime EntryTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? OfficeId { get; set; }
        public Office Office { get; set; }
        // public int? RoleId { get; set; }
        public int? UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}