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
    public class ItemGroupRepository : IItemGroupRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public ItemGroupRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<ItemGroup> AddAsync(ItemGroup entity)
        {
            try
            {
                var Result = await this._dbContext.ItemGroup.AddAsync(entity, CancellationToken.None);

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

        public async Task<ItemGroup> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.ItemGroup.Remove(entity);
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


        public async Task<ItemGroup> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.ItemGroup.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<ItemGroup> GetAll(Expression<Func<ItemGroup, bool>>? filter = null, Func<IQueryable<ItemGroup>, IOrderedQueryable<ItemGroup>>? orderBy = null)
        {
            try
            {
                IQueryable<ItemGroup> query = this._dbContext.ItemGroup;

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

        public async Task<ItemGroup> UpdateAsync(ItemGroup entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.ItemGroup.Where(x=> x.ItemGroupID == entity.ItemGroupID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.ItemGroupName, f => entity.ItemGroupName)
                      .SetProperty(f => f.ItemGroupDescription, f => entity.ItemGroupDescription)
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

        ~ItemGroupRepository()
        {
            Disposed(false);
        }
    }
}
