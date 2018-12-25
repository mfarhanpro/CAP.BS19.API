namespace CAP.BS19.API.DTOs
{
    public class AuthDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int? UserRoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? OfficeId { get; set; }
    }
}