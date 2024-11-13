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
    public class GetAccountType : IRequest<AccountType>
    {
        public int Id { get; set; }

        private class GetAccountTypeHandler : IRequestHandler<GetAccountType, AccountType>
        {
            private readonly IAccountTypeRepository _account;
            public GetAccountTypeHandler(IAccountTypeRepository account)
            {
                this._account = account;
            }
            public async Task<AccountType> Handle(GetAccountType request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._account.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
