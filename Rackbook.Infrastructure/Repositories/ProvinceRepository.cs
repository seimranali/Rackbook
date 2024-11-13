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
    public class ProvinceRepository : IProvinceRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public ProvinceRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Province> AddAsync(Province entity)
        {
            try
            {
                var Result = await this._dbContext.Province.AddAsync(entity, CancellationToken.None);

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

        public async Task<Province> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.Province.Remove(entity);
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


        public async Task<Province> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.Province.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Province> GetAll(Expression<Func<Province, bool>>? filter = null, Func<IQueryable<Province>, IOrderedQueryable<Province>>? orderBy = null)
        {
            try
            {
                IQueryable<Province> query = this._dbContext.Province;

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

        public async Task<Province> UpdateAsync(Province entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.Province.Where(x=> x.ProvinceID == entity.ProvinceID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CountryID, f => entity.CountryID)
                      .SetProperty(f => f.ProvinceCode, f => entity.ProvinceCode)
                      .SetProperty(f => f.ProvinceName, f => entity.ProvinceName)
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

        ~ProvinceRepository()
        {
            Disposed(false);
        }
    }
}
