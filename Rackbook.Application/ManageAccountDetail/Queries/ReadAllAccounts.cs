using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageAccountDetail.Queries
{
    public class ReadAllAccounts : IRequest<IQueryable<vw_Accounts>>
    {

        public Expression<Func<vw_Accounts, bool>>? filter { get; set; }
        public Func<IQueryable<vw_Accounts>, IOrderedQueryable<vw_Accounts>>? orderBy { get; set; }


        private class ReadAllAccountsHandler : IRequestHandler<ReadAllAccounts, IQueryable<vw_Accounts>>
        {
            private readonly IAccountDetailRepository _account;
            public ReadAllAccountsHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<IQueryable<vw_Accounts>> Handle(ReadAllAccounts request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._account.GetAccounts(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
