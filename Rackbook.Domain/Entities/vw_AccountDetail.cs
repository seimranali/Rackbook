using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    [Keyless]
    public record vw_AccountDetail
    {

        public int AccountID { get; set; }
        public int CompanyID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string? AccountDescription { get; set; }
        public int? AccountParentID { get; set; }
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string? AccountTypeDescription { get; set; }
        public int AccountStatementTypeID { get; set; }
        private string? _AccountStatementTypeName;
        [NotMapped]
        public string? AccountStatementTypeName
        {
            get
            {
                if (AccountStatementTypeID == 1)
                    _AccountStatementTypeName = "Balance Sheet";
                else if (AccountStatementTypeID == 2)
                    _AccountStatementTypeName = "Income Statement";

                return _AccountStatementTypeName;
            }
            set
            {
                _AccountStatementTypeName = value;
            }
        }
        public bool IsActive { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }


    }
}
