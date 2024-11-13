using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Models
{
    public class CustomersModel
    {
        public Customers Customers { get; set; }
        public CustomersAddress? CustomersAddress { get; set; }
    }
}
