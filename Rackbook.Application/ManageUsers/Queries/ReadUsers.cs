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
    public class ReadUsers : IRequest<IQueryable<Users>>
    {

        public Expression<Func<Users, bool>>? filter { get; set; }
        public Func<IQueryable<Users>, IOrderedQueryable<Users>>? orderBy { get; set; }


        private class ReadUsersHandler : IRequestHandler<ReadUsers, IQueryable<Users>>
        {
            private readonly IUsersRepository _users;
            public ReadUsersHandler(IUsersRepository users)
            {
                this._users = users;
            }
            public async Task<IQueryable<Users>> Handle(ReadUsers request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._users.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
