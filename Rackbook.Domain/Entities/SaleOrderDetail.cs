using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record SaleOrderDetail
    {
        [Key] //Primary Key
        public int SaleOrderDetailID { get; set; }
        public int SaleOrderID { get; set; }
        public int ItemID { get; set; }
        [NotMapped]
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get
            {
                _TotalAmount = (Quantity * UnitPrice);
                return _TotalAmount;
            }

            set
            {
                value = _TotalAmount;
            }

        }

    }
}
