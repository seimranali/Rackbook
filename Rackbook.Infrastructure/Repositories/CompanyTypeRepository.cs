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
    public class CompanyTypeRepository : ICompanyTypeRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public CompanyTypeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<CompanyType> AddAsync(CompanyType entity)
        {
            try
            {
                var Result = await this._dbContext.CompanyType.AddAsync(entity, CancellationToken.None);

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

        public async Task<CompanyType> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.CompanyType.Remove(entity);
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


        public async Task<CompanyType> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.CompanyType.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<CompanyType> GetAll(Expression<Func<CompanyType, bool>>? filter = null, Func<IQueryable<CompanyType>, IOrderedQueryable<CompanyType>>? orderBy = null)
        {
            try
            {
                IQueryable<CompanyType> query = this._dbContext.CompanyType;

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

        public async Task<CompanyType> UpdateAsync(CompanyType entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.CompanyType.Where(x=> x.CompanyTypeID == entity.CompanyTypeID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyTypeName, f => entity.CompanyTypeName)
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

        ~CompanyTypeRepository()
        {
            Disposed(false);
        }
    }
}
