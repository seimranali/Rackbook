using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageUserRole.Queries
{
    public class ReadUserRole : IRequest<IQueryable<UserRole>>
    {

        public Expression<Func<UserRole, bool>>? filter { get; set; }
        public Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>>? orderBy { get; set; }


        private class ReadUserRoleHandler : IRequestHandler<ReadUserRole, IQueryable<UserRole>>
        {
            private readonly IUserRoleRepository _userRole;
            public ReadUserRoleHandler(IUserRoleRepository userRole)
            {
                this._userRole = userRole;
            }
            public async Task<IQueryable<UserRole>> Handle(ReadUserRole request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._userRole.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
