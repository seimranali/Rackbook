using System.ComponentModel.DataAnnotations;

namespace Rackbook.Domain.Entities
{
    public record ItemGroup
    {
        [Key]
        public int ItemGroupID { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public string ItemGroupName { get; set; }
        public string? ItemGroupDescription { get; set; }
        [Required]
        public int SortOrder { get; set; } = 1;
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
