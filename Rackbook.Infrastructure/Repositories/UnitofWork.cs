using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Infrastructure.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _dbContext;
        public UnitofWork(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
