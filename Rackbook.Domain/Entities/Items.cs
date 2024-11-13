using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    public record Items
    {
        [Key]
        public int ItemID { get; set; }
        public int CompanyID { get; set; }
        public int ItemGroupID { get; set; }
        public int ItemTypeID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public string? UPC { get; set; }
        public string? EAN { get; set; }
        public string? ISBN { get; set; }
        public string? Color { get; set; }
        public int ItemUnitID { get; set; }
        public double PackQuantity { get; set; }
        public double? ItemWeight { get; set; }
        public bool IsInwardTax { get; set; }
        public int? ItemInwardTaxID { get; set; }
        public bool IsOutwardTax { get; set; }
        public int? ItemOutwardTaxID { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal CostUnitPrice { get; set; }
        public decimal SellingUnitPrice { get; set; }
        public int? PurchaseAccountID { get; set; }
        public int? SaleAccountID { get; set; }
        public int? CGSAccountID { get; set; }
        public double? ReorderQuantity { get; set; }
        public string? ItemLogo { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }

    }
}
