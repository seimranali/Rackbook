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
    public class CustomersRepository : ICustomersRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public CustomersRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Customers> AddAsync(Customers entity)
        {
            try
            {
                var Result = await this._dbContext.Customers.AddAsync(entity, CancellationToken.None);

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

        public async Task<Customers> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.Customers.Remove(entity);
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


        public async Task<Customers> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.Customers.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Customers> GetAll(Expression<Func<Customers, bool>>? filter = null, Func<IQueryable<Customers>, IOrderedQueryable<Customers>>? orderBy = null)
        {
            try
            {
                IQueryable<Customers> query = this._dbContext.Customers;

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

        public async Task<Customers> UpdateAsync(Customers entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.Customers.Where(x=> x.CustomerID == entity.CustomerID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.CustomerTypeID, f => entity.CustomerTypeID)
                      .SetProperty(f => f.CustomerCode, f => entity.CustomerCode)
                      .SetProperty(f => f.CustomerName, f => entity.CustomerName)
                      .SetProperty(f => f.CR_Number, f => entity.CR_Number)
                      .SetProperty(f => f.VAT_Number, f => entity.VAT_Number)
                      .SetProperty(f => f.Phone, f => entity.Phone)
                      .SetProperty(f => f.Fax, f => entity.Fax)
                      .SetProperty(f => f.Mobile, f => entity.Mobile)
                      .SetProperty(f => f.Email, f => entity.Email)
                      .SetProperty(f => f.AccountID, f => entity.AccountID)
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

        
        ~CustomersRepository()
        {
            Disposed(false);
        }
    }
}
