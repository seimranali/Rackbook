using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface IGenericRepository<T, U> where T :  notnull 
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(U id);
        Task<T> FindByIDAsync(U id);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = default, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = default);

    }
}
