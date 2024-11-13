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
    public class GetUserRole : IRequest<UserRole>
    {
        public int Id { get; set; }

        private class GetUserRoleHandler : IRequestHandler<GetUserRole, UserRole>
        {
            private readonly IUserRoleRepository _userRole;
            public GetUserRoleHandler(IUserRoleRepository userRole)
            {
                this._userRole = userRole;
            }
            public async Task<UserRole> Handle(GetUserRole request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._userRole.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
