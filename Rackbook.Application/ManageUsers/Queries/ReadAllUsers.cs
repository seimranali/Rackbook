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
    public class ReadAllUsers : IRequest<IQueryable<vw_Users>>
    {

        public Expression<Func<vw_Users, bool>>? filter { get; set; }
        public Func<IQueryable<vw_Users>, IOrderedQueryable<vw_Users>>? orderBy { get; set; }


        private class ReadAllUsersHandler : IRequestHandler<ReadAllUsers, IQueryable<vw_Users>>
        {
            private readonly IUsersRepository _users;
            public ReadAllUsersHandler(IUsersRepository users)
            {
                this._users = users;
            }
            public async Task<IQueryable<vw_Users>> Handle(ReadAllUsers request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._users.GetUsers(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
