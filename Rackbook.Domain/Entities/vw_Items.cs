using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Entities
{
    [Keyless]
    public record vw_Items
    {
        public int ItemID { get; set; }
        public int CompanyID { get; set; }
        public int ItemGroupID { get; set; }
        public string ItemGroupName { get; set; }
        public string? ItemGroupDescription { get; set; }
        public int ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public string? UPC { get; set; }
        public string? EAN { get; set; }
        public string? ISBN { get; set; }
        public string? Color { get; set; }
        public int ItemUnitID { get; set; }
        public string ItemUnitName { get; set; }
        public string? ItemUnitDescription { get; set; }
        public double PackQuantity { get; set; }
        public double? ItemWeight { get; set; }
        public bool IsInwardTax { get; set; }
        public int ItemInwardTaxID { get; set; }
        public bool IsOutwardTax { get; set; }
        public int ItemOutwardTaxID { get; set; }
        public decimal PurchaseUnitPrice { get; set; }
        public decimal? CostUnitPrice { get; set; } = 0;
        public decimal SellingUnitPrice { get; set; }
        public int? PurchaseAccountID { get; set; }
        public int? CGSAccountID { get; set; }
        public int? SaleAccountID { get; set; }
        public double? ReorderQuantity { get; set; }
        public string? ItemLogo { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDateAt { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime? UpdatedDateAt { get; set; }

    }
}
