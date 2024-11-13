using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageAccountType.Queries
{
    public class ReadAccountType : IRequest<IQueryable<AccountType>>
    {

        public Expression<Func<AccountType, bool>>? filter { get; set; }
        public Func<IQueryable<AccountType>, IOrderedQueryable<AccountType>>? orderBy { get; set; }


        private class ReadAccountTypeHandler : IRequestHandler<ReadAccountType, IQueryable<AccountType>>
        {
            private readonly IAccountTypeRepository _account;
            public ReadAccountTypeHandler(IAccountTypeRepository account)
            {
                this._account = account;
            }
            public async Task<IQueryable<AccountType>> Handle(ReadAccountType request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._account.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
