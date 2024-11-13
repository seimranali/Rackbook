using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface IAccountDetailRepository : IGenericRepository<AccountDetail, int>
    {
        IQueryable<vw_AccountDetail> GetAccountDetail(Expression<Func<vw_AccountDetail, bool>>? filter = default, Func<IQueryable<vw_AccountDetail>, IOrderedQueryable<vw_AccountDetail>>? orderBy = default);
        IQueryable<vw_Accounts> GetAccounts(Expression<Func<vw_Accounts, bool>>? filter = default, Func<IQueryable<vw_Accounts>, IOrderedQueryable<vw_Accounts>>? orderBy = default);

    }
}
