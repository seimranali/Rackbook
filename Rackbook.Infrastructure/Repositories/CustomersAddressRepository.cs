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
    public class CustomersAddressRepository : ICustomersAddressRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public CustomersAddressRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<CustomersAddress> AddAsync(CustomersAddress entity)
        {
            try
            {
                var Result = await this._dbContext.CustomersAddress.AddAsync(entity, CancellationToken.None);

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

        public async Task<CustomersAddress> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.CustomersAddress.Remove(entity);
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


        public async Task<CustomersAddress> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.CustomersAddress.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<CustomersAddress> GetAll(Expression<Func<CustomersAddress, bool>>? filter = null, Func<IQueryable<CustomersAddress>, IOrderedQueryable<CustomersAddress>>? orderBy = null)
        {
            try
            {
                IQueryable<CustomersAddress> query = this._dbContext.CustomersAddress;

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

        public async Task<CustomersAddress> UpdateAsync(CustomersAddress entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.CustomersAddress.Where(x=> x.CustomerAddressID == entity.CustomerAddressID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CustomerID, f => entity.CustomerID)
                      .SetProperty(f => f.BillingAddressLine1, f => entity.BillingAddressLine1)
                      .SetProperty(f => f.BillingAddressLine2, f => entity.BillingAddressLine2)
                      .SetProperty(f => f.BillingCountryID, f => entity.BillingCountryID)
                      .SetProperty(f => f.BillingProvinceID, f => entity.BillingProvinceID)
                      .SetProperty(f => f.BillingZipCode, f => entity.BillingZipCode)
                      .SetProperty(f => f.BillingCityName, f => entity.BillingCityName)
                      .SetProperty(f => f.ShippingAddressLine1, f => entity.ShippingAddressLine1)
                      .SetProperty(f => f.ShippingAddressLine2, f => entity.ShippingAddressLine2)
                      .SetProperty(f => f.ShippingCountryID, f => entity.ShippingCountryID)
                      .SetProperty(f => f.ShippingProvinceID, f => entity.ShippingProvinceID)
                      .SetProperty(f => f.ShippingZipCode, f => entity.ShippingZipCode)
                      .SetProperty(f => f.ShippingCityName, f => entity.ShippingCityName));
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


        ~CustomersAddressRepository()
        {
            Disposed(false);
        }
    }
}
