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
    public class NavigationItemRepository : INavigationItemRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public NavigationItemRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<NavigationItem> AddAsync(NavigationItem entity)
        {
            try
            {
                var Result = await this._dbContext.NavigationItem.AddAsync(entity, CancellationToken.None);

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

        public async Task<NavigationItem> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.NavigationItem.Remove(entity);
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


        public async Task<NavigationItem> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.NavigationItem.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<NavigationItem> GetAll(Expression<Func<NavigationItem, bool>>? filter = null, Func<IQueryable<NavigationItem>, IOrderedQueryable<NavigationItem>>? orderBy = null)
        {
            try
            {
                IQueryable<NavigationItem> query = this._dbContext.NavigationItem;

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

        public async Task<NavigationItem> UpdateAsync(NavigationItem entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.NavigationItem.Where(x=> x.NavigationItemID == entity.NavigationItemID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                     .SetProperty(f => f.NavigationItemName, f => entity.NavigationItemName)
                     .SetProperty(f => f.NavigationItemIcon, f => entity.NavigationItemIcon)
                     .SetProperty(f => f.NavigationItemPath, f => entity.NavigationItemName)
                     .SetProperty(f => f.NavigationItemTitle, f => entity.NavigationItemName)
                     .SetProperty(f => f.NavigationItemDescription, f => entity.NavigationItemName)
                     .SetProperty(f => f.ParentNavigationItemID, f => entity.ParentNavigationItemID)
                     .SetProperty(f => f.IsNew, f => entity.IsNew)
                     .SetProperty(f => f.IsUpdate, f => entity.IsUpdate)
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

        public async Task<NavigationItem[]> GetNavigationItems(Expression<Func<NavigationItem, bool>>? filter = null, Func<IQueryable<NavigationItem>, IOrderedQueryable<NavigationItem>>? orderBy = null)
        {
            IQueryable<NavigationItem> query = this._dbContext.NavigationItem;

            if (filter is not null)
                query = query.Where(filter);

            if (orderBy is not null)
                query = orderBy(query);

            query = query.Include("Children")
            .Include("Children.Children")
            .Include("Children.Children.Children")
            .Include("Children.Children.Children.Children");

            return await query.ToArrayAsync<NavigationItem>();
        }

        ~NavigationItemRepository()
        {
            Disposed(false);
        }
    }
}
