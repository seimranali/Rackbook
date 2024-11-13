using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record JournalEntryDetail
    {
        [Key]
        public int JournalEntryDetailID { get; set; }
        public int JournalEntryID { get; set; }
        public int AccountID { get; set; }
        public string Comments { get; set; }
        public decimal Debit_Amount { get; set; }
        public decimal Credit_Amount { get; set; }
        public bool? IsReconciled { get; set; }
        public int? Entry_Number { get; set; }

    }
}
