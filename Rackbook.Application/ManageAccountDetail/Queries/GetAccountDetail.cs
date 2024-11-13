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
    public class GetAccountDetail : IRequest<AccountDetail>
    {
        public int Id { get; set; }

        private class GetAccountDetailHandler : IRequestHandler<GetAccountDetail, AccountDetail>
        {
            private readonly IAccountDetailRepository _account;
            public GetAccountDetailHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<AccountDetail> Handle(GetAccountDetail request, CancellationToken cancellationToken)
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
