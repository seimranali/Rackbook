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
    public class JournalEntryDetailRepository : IJournalEntryDetailRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public JournalEntryDetailRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<JournalEntryDetail> AddAsync(JournalEntryDetail entity)
        {
            try
            {
                var Result = await this._dbContext.JournalEntryDetail.AddAsync(entity, CancellationToken.None);

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

        public async Task<JournalEntryDetail> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.JournalEntryDetail.Remove(entity);
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


        public async Task<JournalEntryDetail> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.JournalEntryDetail.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<JournalEntryDetail> GetAll(Expression<Func<JournalEntryDetail, bool>>? filter = null, Func<IQueryable<JournalEntryDetail>, IOrderedQueryable<JournalEntryDetail>>? orderBy = null)
        {
            try
            {
                IQueryable<JournalEntryDetail> query = this._dbContext.JournalEntryDetail;

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

        public async Task<JournalEntryDetail> UpdateAsync(JournalEntryDetail entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.JournalEntryDetail.Where(x=> x.JournalEntryDetailID == entity.JournalEntryDetailID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.JournalEntryID, f => entity.JournalEntryID)
                      .SetProperty(f => f.AccountID, f => entity.AccountID)
                      .SetProperty(f => f.Comments, f => entity.Comments)
                      .SetProperty(f => f.Debit_Amount, f => entity.Debit_Amount)
                      .SetProperty(f => f.Credit_Amount, f => entity.Credit_Amount)
                      .SetProperty(f => f.IsReconciled, f => entity.IsReconciled)
                      .SetProperty(f => f.Entry_Number, f => entity.Entry_Number));
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

        ~JournalEntryDetailRepository()
        {
            Disposed(false);
        }
    }
}
