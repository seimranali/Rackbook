using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record Users
    {
        [Key]
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public int UserRoleID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpired { get; set; }
        public string? OTP { get; set; }
        public DateTime? OTPExpired { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
