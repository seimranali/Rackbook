using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Rackbook.Infrastructure.Repositories
{
    public class AccountDetailRepository : IAccountDetailRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public AccountDetailRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<AccountDetail> AddAsync(AccountDetail entity)
        {
            try
            {
                var Result = await this._dbContext.AccountDetail.AddAsync(entity, CancellationToken.None);

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

        public async Task<AccountDetail> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.AccountDetail.Remove(entity);
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


        public async Task<AccountDetail> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.AccountDetail.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<AccountDetail> GetAll(Expression<Func<AccountDetail, bool>>? filter = null, Func<IQueryable<AccountDetail>, IOrderedQueryable<AccountDetail>>? orderBy = null)
        {
            try
            {
                IQueryable<AccountDetail> query = this._dbContext.AccountDetail;

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

        public async Task<AccountDetail> UpdateAsync(AccountDetail entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.AccountDetail.Where(x=> x.AccountID == entity.AccountID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.AccountNumber, f => entity.AccountNumber)
                      .SetProperty(f => f.AccountName, f => entity.AccountName)
                      .SetProperty(f => f.AccountDescription, f => entity.AccountDescription)
                      .SetProperty(f => f.AccountParentID, f => entity.AccountParentID)
                      .SetProperty(f => f.AccountTypeID, f => entity.AccountTypeID)
                      .SetProperty(f => f.AccountStatementTypeID, f => entity.AccountStatementTypeID)
                      .SetProperty(f => f.IsActive, f => entity.IsActive)
                      .SetProperty(f => f.CreatedUserID, f => entity.CreatedUserID)
                      .SetProperty(f => f.CreatedDateAt, f => entity.CreatedDateAt)
                      .SetProperty(f => f.UpdatedUserID, f => entity.UpdatedUserID)
                      .SetProperty(f => f.UpdatedDateAt, f => entity.UpdatedDateAt));
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

        public IQueryable<vw_AccountDetail> GetAccountDetail(Expression<Func<vw_AccountDetail, bool>>? filter = null, Func<IQueryable<vw_AccountDetail>, IOrderedQueryable<vw_AccountDetail>>? orderBy = null)
        {
            try
            {
                IQueryable<vw_AccountDetail> query = this._dbContext.vw_AccountDetail;

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

        public IQueryable<vw_Accounts> GetAccounts(Expression<Func<vw_Accounts, bool>>? filter = null, Func<IQueryable<vw_Accounts>, IOrderedQueryable<vw_Accounts>>? orderBy = null)
        {
            try
            {
                IQueryable<vw_Accounts> query = this._dbContext.vw_Accounts;

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

        ~AccountDetailRepository()
        {
            Disposed(false);
        }
    }
}
