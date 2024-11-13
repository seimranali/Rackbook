using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageUsers.Queries
{
    public class GetUsers : IRequest<Users>
    {
        public int Id { get; set; }

        private class GetUsersHandler : IRequestHandler<GetUsers, Users>
        {
            private readonly IUsersRepository _users;
            public GetUsersHandler(IUsersRepository users)
            {
                this._users = users;
            }
            public async Task<Users> Handle(GetUsers request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._users.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
