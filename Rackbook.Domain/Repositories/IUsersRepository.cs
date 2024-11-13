using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface IUsersRepository : IGenericRepository<Users, int>
    {
        Task<bool> UpdateUserStatus(int UserID, bool IsActive);
        IQueryable<vw_Users> GetUsers(Expression<Func<vw_Users, bool>>? filter = default, Func<IQueryable<vw_Users>, IOrderedQueryable<vw_Users>>? orderBy = default);
    }
}
