using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface IItemsRepository : IGenericRepository<Items, int>
    {
        IQueryable<vw_Items> GetAllItems(Expression<Func<vw_Items, bool>>? filter = default, Func<IQueryable<vw_Items>, IOrderedQueryable<vw_Items>>? orderBy = default);

    }
}
