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
    public class ItemUnitRepository : IItemUnitRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public ItemUnitRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<ItemUnit> AddAsync(ItemUnit entity)
        {
            try
            {
                var Result = await this._dbContext.ItemUnit.AddAsync(entity, CancellationToken.None);

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

        public async Task<ItemUnit> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.ItemUnit.Remove(entity);
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


        public async Task<ItemUnit> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.ItemUnit.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<ItemUnit> GetAll(Expression<Func<ItemUnit, bool>>? filter = null, Func<IQueryable<ItemUnit>, IOrderedQueryable<ItemUnit>>? orderBy = null)
        {
            try
            {
                IQueryable<ItemUnit> query = this._dbContext.ItemUnit;

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

        public async Task<ItemUnit> UpdateAsync(ItemUnit entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.ItemUnit.Where(x=> x.ItemUnitID == entity.ItemUnitID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.ItemUnitName, f => entity.ItemUnitName)
                      .SetProperty(f => f.ItemUnitDescription, f => entity.ItemUnitDescription)
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

        ~ItemUnitRepository()
        {
            Disposed(false);
        }
    }
}
