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
    public class ItemsRepository : IItemsRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public ItemsRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Items> AddAsync(Items entity)
        {
            try
            {
                var Result = await this._dbContext.Items.AddAsync(entity, CancellationToken.None);

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

        public async Task<Items> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.Items.Remove(entity);
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


        public async Task<Items> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.Items.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Items> GetAll(Expression<Func<Items, bool>>? filter = null, Func<IQueryable<Items>, IOrderedQueryable<Items>>? orderBy = null)
        {
            try
            {
                IQueryable<Items> query = this._dbContext.Items;

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

        public async Task<Items> UpdateAsync(Items entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.Items.Where(x=> x.ItemID == entity.ItemID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                      .SetProperty(f => f.ItemGroupID, f => entity.ItemGroupID)
                      .SetProperty(f => f.ItemTypeID, f => entity.ItemTypeID)
                      .SetProperty(f => f.ItemCode, f => entity.ItemCode)
                      .SetProperty(f => f.ItemName, f => entity.ItemName)
                      .SetProperty(f => f.ItemDescription, f => entity.ItemDescription)
                      .SetProperty(f => f.UPC, f => entity.UPC)
                      .SetProperty(f => f.EAN, f => entity.EAN)
                      .SetProperty(f => f.ISBN, f => entity.ISBN)
                      .SetProperty(f => f.Color, f => entity.Color)
                      .SetProperty(f => f.PackQuantity, f => entity.PackQuantity)
                      .SetProperty(f => f.ItemWeight, f => entity.ItemWeight)
                      .SetProperty(f => f.IsInwardTax, f => entity.IsInwardTax)
                      .SetProperty(f => f.ItemInwardTaxID, f => entity.ItemInwardTaxID)
                      .SetProperty(f => f.IsOutwardTax, f => entity.IsOutwardTax)
                      .SetProperty(f => f.ItemOutwardTaxID, f => entity.ItemOutwardTaxID)
                      .SetProperty(f => f.PurchaseUnitPrice, f => entity.PurchaseUnitPrice)
                      .SetProperty(f => f.CostUnitPrice, f => entity.CostUnitPrice)
                      .SetProperty(f => f.SellingUnitPrice, f => entity.SellingUnitPrice)
                      .SetProperty(f => f.PurchaseAccountID, f => entity.PurchaseAccountID)
                      .SetProperty(f => f.SaleAccountID, f => entity.SaleAccountID)
                      .SetProperty(f => f.CGSAccountID, f => entity.CGSAccountID)
                      .SetProperty(f => f.ReorderQuantity, f => entity.ReorderQuantity)
                      .SetProperty(f => f.ItemLogo, f => entity.ItemLogo)
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

        public IQueryable<vw_Items> GetAllItems(Expression<Func<vw_Items, bool>>? filter = null, Func<IQueryable<vw_Items>, IOrderedQueryable<vw_Items>>? orderBy = null)
        {
            try
            {
                IQueryable<vw_Items> query = this._dbContext.vw_Items;

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

        ~ItemsRepository()
        {
            Disposed(false);
        }
    }
}
