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
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public CompanyRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Company> AddAsync(Company entity)
        {
            try
            {
                var Result = await this._dbContext.Company.AddAsync(entity, CancellationToken.None);

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

        public async Task<Company> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.Company.Remove(entity);
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


        public async Task<Company> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.Company.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Company> GetAll(Expression<Func<Company, bool>>? filter = null, Func<IQueryable<Company>, IOrderedQueryable<Company>>? orderBy = null)
        {
            try
            {
                IQueryable<Company> query = this._dbContext.Company;

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

        public async Task<Company> UpdateAsync(Company entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.Company.Where(x=> x.CompanyID == entity.CompanyID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                     .SetProperty(f => f.CompanyTypeID, f => entity.CompanyTypeID)
                      .SetProperty(f => f.CompanyName, f => entity.CompanyName)
                      .SetProperty(f => f.EmployerIdentificationNo, f => entity.EmployerIdentificationNo)
                      .SetProperty(f => f.TaxIdentificationNo, f => entity.TaxIdentificationNo)
                      .SetProperty(f => f.Phone, f => entity.Phone)
                      .SetProperty(f => f.Email, f => entity.Email)
                      .SetProperty(f => f.Website, f => entity.Website)
                      .SetProperty(f => f.AddressLine1, f => entity.AddressLine1)
                      .SetProperty(f => f.AddressLine2, f => entity.AddressLine2)
                      .SetProperty(f => f.CountryID, f => entity.CountryID)
                      .SetProperty(f => f.ProvinceID, f => entity.ProvinceID)
                      .SetProperty(f => f.ZipCode, f => entity.ZipCode)
                      .SetProperty(f => f.CityName, f => entity.CityName)
                      .SetProperty(f => f.CompanyLogo, f => entity.CompanyLogo)
                      .SetProperty(f => f.IsActive, f => entity.IsActive)
                      .SetProperty(f => f.CreatedDate, f => entity.CreatedDate)
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

        public async Task<bool> UpdateCompanyStatus(int CompanyID, bool IsActive)
        {
            try
            {
                if (CompanyID > 0)
                {
                    int ReturnID =  await this._dbContext.Company.Where(x=> x.CompanyID == CompanyID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.IsActive, f => IsActive)
                      );
                    if (ReturnID > 0)
                        return true;
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

        ~CompanyRepository()
        {
            Disposed(false);
        }
    }
}
