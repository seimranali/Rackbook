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
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private bool IsDisposed;

        public UsersRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Users> AddAsync(Users entity)
        {
            try
            {
                var Result = await this._dbContext.Users.AddAsync(entity, CancellationToken.None);

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

        public async Task<Users> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIDAsync(id);
                if (entity is not null)
                {
                    this._dbContext.Users.Remove(entity);
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


        public async Task<Users> FindByIDAsync(int id)
        {
            try
            {
                return await this._dbContext.Users.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Users> GetAll(Expression<Func<Users, bool>>? filter = null, Func<IQueryable<Users>, IOrderedQueryable<Users>>? orderBy = null)
        {
            try
            {
                IQueryable<Users> query = this._dbContext.Users;

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

        public async Task<Users> UpdateAsync(Users entity)
        {
            try
            {
                if (entity is not null)
                {
                    int ReturnID =  await this._dbContext.Users.Where(x=> x.UserID == entity.UserID).ExecuteUpdateAsync(t =>
                     t.SetProperty(f => f.CompanyID, f => entity.CompanyID)
                     .SetProperty(f => f.UserRoleID, f => entity.UserRoleID)
                     .SetProperty(f => f.FullName, f => entity.FullName)
                     .SetProperty(f => f.UserName, f => entity.UserName)
                     .SetProperty(f => f.Mobile, f => entity.Mobile)
                     .SetProperty(f => f.Email, f => entity.Email)
                     .SetProperty(f => f.Password, f => entity.Password)
                     .SetProperty(f => f.PasswordExpired, f => entity.PasswordExpired)
                     .SetProperty(f => f.OTP, f => entity.OTP)
                     .SetProperty(f => f.OTPExpired , f => entity.OTPExpired)
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

        public async Task<bool> UpdateUserStatus(int UserID, bool IsActive)
        {
            try
            {
                if (UserID > 0)
                {
                    int ReturnID =  await this._dbContext.Users.Where(x=> x.UserID == UserID).ExecuteUpdateAsync(t =>
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

        public void Dispose()
        {
            if (!IsDisposed)
                Disposed(true);

            GC.SuppressFinalize(this);
        }

        public IQueryable<vw_Users> GetUsers(Expression<Func<vw_Users, bool>>? filter = null, Func<IQueryable<vw_Users>, IOrderedQueryable<vw_Users>>? orderBy = null)
        {
            try
            {
                IQueryable<vw_Users> query = this._dbContext.vw_Users;

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

        ~UsersRepository()
        {
            Disposed(false);
        }
    }
}
