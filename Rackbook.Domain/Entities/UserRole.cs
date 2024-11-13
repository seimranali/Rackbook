using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record UserRole
    {
        [Key]
        public int UserRoleID { get; set; }
        public int CompanyID { get; set; }
        public string UserRoleName { get; set; }
        public string? UserRoleDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 1;
    }
}
