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
    public class SaleOrderDetailRepository : ISaleOrderDetailRepository
    {

        private readonly AppDbContext _dbContext;

        public SaleOrderDetailRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<SaleOrderDetail> AddAsync(SaleOrderDetail entity)
        {
            try
            {

                var Result = await this._dbContext.SaleOrderDetail.AddAsync(entity);

                if (Result.Entity is not null)
                    return Result.Entity;

                else

                    throw new Exception("An error occured while insert record");


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> AddRangeAsync(List<SaleOrderDetail> entities)
        {
            try
            {


                await this._dbContext.SaleOrderDetail.AddRangeAsync(entities);
                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SaleOrderDetail> DeleteAsync(int id)
        {
            try
            {

                var entity = await FindByIDAsync(id);

                if (entity is not null)
                {

                    this._dbContext.SaleOrderDetail.Remove(entity);

                }
                else
                {
                    throw new Exception("an error occured while delete record");
                }

                return entity;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SaleOrderDetail> FindByIDAsync(int id)
        {
            return await this._dbContext.SaleOrderDetail.FindAsync(id);
        }

        public IQueryable<SaleOrderDetail> GetAll(Expression<Func<SaleOrderDetail, bool>>? filter = null, Func<IQueryable<SaleOrderDetail>, IOrderedQueryable<SaleOrderDetail>>? orderBy = null)
        {
            try
            {

                IQueryable<SaleOrderDetail> query = this._dbContext.SaleOrderDetail;

                if (filter is not null)
                    query = query.Where(filter);

                if (orderBy is not null)
                    query = orderBy(query);


                return query;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> RemoveRangeAsync(List<SaleOrderDetail> entities)
        {
            try
            {
                this._dbContext.SaleOrderDetail.RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SaleOrderDetail> UpdateAsync(SaleOrderDetail entity)
        {
            try
            {

                var ReturnID = await this._dbContext.SaleOrderDetail.Where(x=> x.SaleOrderID == entity.SaleOrderID)
                    .ExecuteUpdateAsync(f=> f.SetProperty(c=> c.ItemID, c=> entity.ItemID)
                                            .SetProperty(c=> c.Quantity, c=> entity.Quantity)
                                            .SetProperty(c=> c.UnitPrice, c=> entity.UnitPrice)
                                            .SetProperty(c=> c.TotalAmount, c=> entity.TotalAmount));


                if (ReturnID > 0)
                    return entity;
                else
                    throw new Exception("An error occurred while update record");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
