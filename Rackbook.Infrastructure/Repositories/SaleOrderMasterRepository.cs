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
    public class SaleOrderMasterRepository : ISaleOrderMasterRepository
    {

        private readonly AppDbContext _dbContext;
        public SaleOrderMasterRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<SaleOrderMaster> AddAsync(SaleOrderMaster entity)
        {
            try
            {

                var Result = await this._dbContext.SaleOrderMaster.AddAsync(entity);

                if (Result.Entity is not null)
                {
                    return Result.Entity;

                }
                else
                {

                    throw new Exception("An error occurred while insert record");
                }



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SaleOrderMaster> DeleteAsync(int id)
        {
            try
            {


                var entity = await FindByIDAsync(id);

                if (entity is not null)
                {
                    this._dbContext.SaleOrderMaster.Remove(entity);
                }
                else
                {

                    throw new Exception("An error occured while delete record");
                }

                return entity;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SaleOrderMaster> FindByIDAsync(int id)
        {
            return await this._dbContext.SaleOrderMaster.FindAsync(id);
        }

        public IQueryable<SaleOrderMaster> GetAll(Expression<Func<SaleOrderMaster, bool>>? filter = null, Func<IQueryable<SaleOrderMaster>, IOrderedQueryable<SaleOrderMaster>>? orderBy = null)
        {
            try
            {
                IQueryable<SaleOrderMaster> query = this._dbContext.SaleOrderMaster;

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

        public async Task<SaleOrderMaster> UpdateAsync(SaleOrderMaster entity)
        {
            try
            {




                var ReturnID = await this._dbContext.SaleOrderMaster.Where(x=> x.SaleOrderID == entity.SaleOrderID)
                    .ExecuteUpdateAsync(f=> f.SetProperty(c=> c.SaleOrderDate, c=> entity.SaleOrderDate)
                                            .SetProperty(c=> c.SaleOrderNumber, c=> entity.SaleOrderNumber)
                                            .SetProperty(c=> c.CustomerId, c=> entity.CustomerId)
                                            .SetProperty(c=> c.SalePerson, c=> entity.SalePerson)
                                            .SetProperty(c=> c.Remarks, c=> entity.Remarks)
                                            .SetProperty(c=> c.Terms_And_Condition, c=> entity.Terms_And_Condition)
                                            .SetProperty(c=> c.TotalQuantity, c=> entity.TotalQuantity)
                                            .SetProperty(c=> c.TotalAmount, c=> entity.TotalAmount)
                                            .SetProperty(c=> c.CreatedUserID, c=> entity.CreatedUserID)
                                            .SetProperty(c=> c.CreatedDateAt, c=> entity.CreatedDateAt)
                                            .SetProperty(c=> c.UpdatedUserID, c=> entity.UpdatedUserID)
                                            .SetProperty(c=> c.UpdatedDateAt, c=> entity.UpdatedDateAt));


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
