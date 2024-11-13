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
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public CountryRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Country> AddAsync(Country entity)
        {
            try
            {
                var Result = await this._dbContext.Country.AddAsync(entity, CancellationToken.None);

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

        public async Task<Country> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.Country.Remove(entity);
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


        public async Task<Country> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.Country.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Country> GetAll(Expression<Func<Country, bool>>? filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null)
        {
            try
            {
                IQueryable<Country> query = this._dbContext.Country;

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

        public async Task<Country> UpdateAsync(Country entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.Country.Where(x=> x.CountryID == entity.CountryID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CountryCode, f => entity.CountryCode)
                      .SetProperty(f => f.CountryName, f => entity.CountryName)
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

        ~CountryRepository()
        {
            Disposed(false);
        }
    }
}
