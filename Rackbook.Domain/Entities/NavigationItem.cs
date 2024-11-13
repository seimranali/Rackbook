using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record NavigationItem
    {
        [Key]
        public int NavigationItemID { get; set; }
        public int CompanyID { get; set; }
        public string NavigationItemName { get; set; }
        public string? NavigationItemIcon { get; set; }
        public string? NavigationItemPath { get; set; }
        public string? NavigationItemTitle { get; set; }
        public string? NavigationItemDescription { get; set; }
        [ForeignKey("ParentNavigationItemID")]
        public NavigationItem? Child { get; set; }
        public int? ParentNavigationItemID { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsUpdate { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }
        [InverseProperty("Child")]
        public ICollection<NavigationItem>? Children { get; set; }

    }
}
