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
    public class UserRoleRepository : IUserRoleRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public UserRoleRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<UserRole> AddAsync(UserRole entity)
        {
            try
            {
                var Result = await this._dbContext.UserRole.AddAsync(entity, CancellationToken.None);

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

        public async Task<UserRole> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.UserRole.Remove(entity);
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


        public async Task<UserRole> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.UserRole.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<UserRole> GetAll(Expression<Func<UserRole, bool>>? filter = null, Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>>? orderBy = null)
        {
            try
            {
                IQueryable<UserRole> query = this._dbContext.UserRole;

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

        public async Task<UserRole> UpdateAsync(UserRole entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.UserRole.Where(x=> x.UserRoleID == entity.UserRoleID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.UserRoleName, f => entity.UserRoleName)
                     .SetProperty(f => f.UserRoleDescription, f => entity.UserRoleDescription)
                     .SetProperty(f => f.IsActive, f => entity.IsActive)
                     .SetProperty(f => f.SortOrder, f => entity.SortOrder)
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

        ~UserRoleRepository()
        {
            Disposed(false);
        }
    }
}
