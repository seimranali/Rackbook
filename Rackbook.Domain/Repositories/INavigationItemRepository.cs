using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface INavigationItemRepository : IGenericRepository<NavigationItem, int>
    {

        Task<NavigationItem[]> GetNavigationItems(Expression<Func<NavigationItem, bool>>? filter = default, Func<IQueryable<NavigationItem>, IOrderedQueryable<NavigationItem>>? orderBy = default);

    }
}
