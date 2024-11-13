using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record Province
    {
        [Key]
        public int ProvinceID { get; set; }
        public int CountryID { get; set; }
        public string? ProvinceCode { get; set; }
        public string ProvinceName { get; set; }

    }
}
