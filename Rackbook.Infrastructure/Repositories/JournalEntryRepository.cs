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
    public class JournalEntryRepository : IJournalEntryRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public JournalEntryRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<JournalEntry> AddAsync(JournalEntry entity)
        {
            try
            {
                var Result = await this._dbContext.JournalEntry.AddAsync(entity, CancellationToken.None);

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

        public async Task<JournalEntry> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.JournalEntry.Remove(entity);
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


        public async Task<JournalEntry> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.JournalEntry.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<JournalEntry> GetAll(Expression<Func<JournalEntry, bool>>? filter = null, Func<IQueryable<JournalEntry>, IOrderedQueryable<JournalEntry>>? orderBy = null)
        {
            try
            {
                IQueryable<JournalEntry> query = this._dbContext.JournalEntry;

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

        public async Task<JournalEntry> UpdateAsync(JournalEntry entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.JournalEntry.Where(x=> x.JournalEntryID == entity.JournalEntryID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.JournalEntryTypeID, f => entity.JournalEntryTypeID)
                      .SetProperty(f => f.JournalEntryDate, f => entity.JournalEntryDate)
                      .SetProperty(f => f.JournalEntryNumber, f => entity.JournalEntryNumber)
                      .SetProperty(f => f.AccountID, f => entity.AccountID)
                      .SetProperty(f => f.Remarks, f => entity.Remarks)
                      .SetProperty(f => f.TotalAmount, f => entity.TotalAmount)
                      .SetProperty(f => f.SourcePath, f => entity.SourcePath)
                      .SetProperty(f => f.ReferenceID, f => entity.ReferenceID)
                      .SetProperty(f => f.JournalEntryStatusID, f => entity.JournalEntryStatusID)
                      .SetProperty(f => f.CreatedUserID, f => entity.CreatedUserID)
                      .SetProperty(f => f.CreatedDateAt, f => entity.CreatedDateAt)
                      .SetProperty(f => f.UpdatedUserID, f => entity.UpdatedUserID)
                      .SetProperty(f => f.UpdatedDateAt, f => entity.UpdatedDateAt)
                      .SetProperty(f => f.AuthorizedUserID, f => entity.AuthorizedUserID)
                      .SetProperty(f => f.AuthorizedDateAt, f => entity.AuthorizedDateAt));
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

        public async Task<bool> UpdateStatus(int JournalEntryID, int JournalEntryStatusID, int UserID)
        {
            try
            {
                var entity = await this.FindByIDAsync(JournalEntryID);
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.JournalEntry.Where(x=> x.JournalEntryID == entity.JournalEntryID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.JournalEntryStatusID, f => entity.JournalEntryStatusID)
                      .SetProperty(f => f.UpdatedUserID, f => UserID)
                      .SetProperty(f => f.UpdatedDateAt, f => DateTime.UtcNow));
                    if (ReturnID > 0)
                        return true;
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
        public async Task<bool> UpdateAuthorizStatus(int JournalEntryID, int JournalEntryStatusID, int UserID)
        {
            try
            {
                var entity = await this.FindByIDAsync(JournalEntryID);
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.JournalEntry.Where(x=> x.JournalEntryID == entity.JournalEntryID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.JournalEntryStatusID, f => entity.JournalEntryStatusID)
                      .SetProperty(f => f.UpdatedUserID, f => !f.UpdatedUserID.HasValue ? UserID:f.UpdatedUserID)
                      .SetProperty(f => f.UpdatedDateAt, f => !f.UpdatedUserID.HasValue ? DateTime.UtcNow:f.UpdatedDateAt)
                      .SetProperty(f => f.AuthorizedUserID, f => UserID)
                      .SetProperty(f => f.AuthorizedDateAt, f => DateTime.UtcNow));
                    if (ReturnID > 0)
                        return true;
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

        ~JournalEntryRepository()
        {
            Disposed(false);
        }
    }
}
