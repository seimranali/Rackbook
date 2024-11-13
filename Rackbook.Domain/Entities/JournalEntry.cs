using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record JournalEntry
    {
        [Key]
        public int JournalEntryID { get; set; }
        public int CompanyID { get; set; }
        public int JournalEntryTypeID { get; set; }
        public DateTime JournalEntryDate { get; set; }
        public string JournalEntryNumber { get; set; }
        public int? AccountID { get; set; }
        public string? Remarks { get; set; }
        public decimal TotalAmount { get; set; }
        public string SourcePath { get; set; }
        public int? ReferenceID { get; set; }
        public int JournalEntryStatusID { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }
        public int? AuthorizedUserID { get; set; }
        public DateTime? AuthorizedDateAt { get; set; }

    }
}
