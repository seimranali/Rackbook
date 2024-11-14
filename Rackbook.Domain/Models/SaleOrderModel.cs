using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Models
{
    public class SaleOrderModel
    {
        public SaleOrderMaster SaleOrderMaster { get; set; }
        public List<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
