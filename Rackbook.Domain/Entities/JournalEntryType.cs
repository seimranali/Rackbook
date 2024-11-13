using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record JournalEntryType
    {
        [Key]
        public int JournalEntryTypeID { get; set; }
        public int CompanyID { get; set; }
        public string JournalEntryTypeName { get; set; }
        public string? JournalEntryTypeDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 1;
    }
}
