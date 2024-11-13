using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record ItemUnit
    {
        [Key]
        public int ItemUnitID { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public string ItemUnitName { get; set; }
        public string? ItemUnitDescription { get; set; }
        [Required]
        public int SortOrder { get; set; } = 1;
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
