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
    public class JournalEntryTypeRepository : IJournalEntryTypeRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public JournalEntryTypeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<JournalEntryType> AddAsync(JournalEntryType entity)
        {
            try
            {
                var Result = await this._dbContext.JournalEntryType.AddAsync(entity, CancellationToken.None);

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

        public async Task<JournalEntryType> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.JournalEntryType.Remove(entity);
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


        public async Task<JournalEntryType> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.JournalEntryType.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<JournalEntryType> GetAll(Expression<Func<JournalEntryType, bool>>? filter = null, Func<IQueryable<JournalEntryType>, IOrderedQueryable<JournalEntryType>>? orderBy = null)
        {
            try
            {
                IQueryable<JournalEntryType> query = this._dbContext.JournalEntryType;

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

        public async Task<JournalEntryType> UpdateAsync(JournalEntryType entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.JournalEntryType.Where(x=> x.JournalEntryTypeID == entity.JournalEntryTypeID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.JournalEntryTypeName, f => entity.JournalEntryTypeName)
                      .SetProperty(f => f.JournalEntryTypeDescription, f => entity.JournalEntryTypeDescription)
                      .SetProperty(f => f.SortOrder, f => entity.SortOrder)
                      .SetProperty(f => f.IsActive, f => entity.IsActive)
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

        ~JournalEntryTypeRepository()
        {
            Disposed(false);
        }
    }
}
