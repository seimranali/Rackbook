using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Rackbook.Domain.Entities
{
    [Keyless]
    public record vw_Users
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public int CompanyTypeID { get; set; }
        public string CompanyTypeName { get; set; }
        public string CompanyName { get; set; }
        public string? EmployerIdentificationNo { get; set; }
        public string? TaxIdentificationNo { get; set; }
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; }
        public string? UserRoleDescription { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpired { get; set; }
        public string? OTP { get; set; }
        public DateTime? OTPExpired { get; set; }
        public bool IsActive { get; set; }

    }
}
