using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public int CompanyID { get; set; }
        public int CustomerTypeID { get; set; } = 1;
        private string? _CustomerTypeName;
        [NotMapped]
        public string? CustomerTypeName
        {

            get
            {
                if (CustomerTypeID == 1)
                    _CustomerTypeName = "Business";
                else if (CustomerTypeID == 2)
                    _CustomerTypeName = "Individual";

                return _CustomerTypeName;
            }
            set
            {
                value = _CustomerTypeName;
            }

        }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string? CR_Number { get; set; }
        public string? VAT_Number { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public int? AccountID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }

    }

    public record CustomersAddress
    {
        [Key]
        public int CustomerAddressID { get; set; }
        public int CustomerID { get; set; }
        public string? BillingAddressLine1 { get; set; }
        public string? BillingAddressLine2 { get; set; }
        public int? BillingCountryID { get; set; }
        public int? BillingProvinceID { get; set; }
        public string? BillingZipCode { get; set; }
        public string? BillingCityName { get; set; }
        public string? ShippingAddressLine1 { get; set; }
        public string? ShippingAddressLine2 { get; set; }
        public int? ShippingCountryID { get; set; }
        public int? ShippingProvinceID { get; set; }
        public string? ShippingZipCode { get; set; }
        public string? ShippingCityName { get; set; }

    }
}
