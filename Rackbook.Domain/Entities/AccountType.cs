using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record AccountType
    {
        [Key]
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string? AccountTypeDescription { get; set; }

    }
}
