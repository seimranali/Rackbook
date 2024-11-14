using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface ISaleOrderDetailRepository : IGenericRepository<SaleOrderDetail, int>
    {

        Task<bool> AddRangeAsync(List<SaleOrderDetail> entities);
        Task<bool> RemoveRangeAsync(List<SaleOrderDetail> entities);


    }
}
