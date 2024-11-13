namespace Rackbook.WebUI.Services
{
    public class UserSession
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string UserRoleName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public int CompanyID { get; set; }
    }
}
