using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record AccountDetail
    {
        [Key]
        public int AccountID { get; set; }
        public int CompanyID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string? AccountDescription { get; set; }
        public int? AccountParentID { get; set; }
        public int AccountTypeID { get; set; }
        public int AccountStatementTypeID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }       
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }      

    }
}
