using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record CompanyType
    {
        [Key]
        public int CompanyTypeID { get; set; }
        public string CompanyTypeName { get; set; }
    }
}
