using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record SaleOrderMaster
    {
        [Key] //Primary Key
        public int SaleOrderID { get; set; }
        public DateTime SaleOrderDate { get; set; }
        public string SaleOrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string? SalePerson { get; set; }
        public string? Remarks { get; set; }
        public string? Terms_And_Condition { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }

    }
}
