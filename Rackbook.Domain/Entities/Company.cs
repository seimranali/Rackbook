using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record Company
    {
        [Key]
        public int CompanyID { get; set; }
        [Required]
        public int CompanyTypeID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string? EmployerIdentificationNo { get; set; }
        public string? TaxIdentificationNo { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryID { get; set; }
        public int? ProvinceID { get; set; }
        public string? ZipCode { get; set; }
        public string? CityName { get; set; }
        public string? CompanyLogo { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
