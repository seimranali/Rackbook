using Microsoft.EntityFrameworkCore;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Infrastructure.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public AccountTypeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<AccountType> AddAsync(AccountType entity)
        {
            try
            {
                var Result = await this._dbContext.AccountType.AddAsync(entity, CancellationToken.None);

                if (Result.Entity != null)
                    return Result.Entity;
                else
                    throw new Exception("An error occurred while insert record.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccountType> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.AccountType.Remove(entity);
                    return entity;
                }
                else
                {
                    throw new Exception("An error occurred while delete record.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Disposed(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            IsDisposed = true;
        }


        public async Task<AccountType> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.AccountType.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<AccountType> GetAll(Expression<Func<AccountType, bool>>? filter = null, Func<IQueryable<AccountType>, IOrderedQueryable<AccountType>>? orderBy = null)
        {
            try
            {
                IQueryable<AccountType> query = this._dbContext.AccountType;

                if (filter is not null)
                    query = query.Where(filter);

                if (orderBy is not null)
                    query = orderBy(query);

                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AccountType> UpdateAsync(AccountType entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.AccountType.Where(x=> x.AccountTypeID == entity.AccountTypeID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.AccountTypeName, f => entity.AccountTypeName)
                     .SetProperty(f => f.AccountTypeDescription, f => entity.AccountTypeDescription)
                      );
                    if (ReturnID > 0)
                        return entity;
                    else
                        throw new Exception("An error occurred while update record.");
                }
                else
                {
                    throw new Exception("An error occurred while update record.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (!IsDisposed)
                Disposed(true);

            GC.SuppressFinalize(this);
        }

        ~AccountTypeRepository()
        {
            Disposed(false);
        }
    }
}
