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
    public class ReadAllAccountDetail : IRequest<IQueryable<vw_AccountDetail>>
    {

        public Expression<Func<vw_AccountDetail, bool>>? filter { get; set; }
        public Func<IQueryable<vw_AccountDetail>, IOrderedQueryable<vw_AccountDetail>>? orderBy { get; set; }


        private class ReadAllAccountDetailHandler : IRequestHandler<ReadAllAccountDetail, IQueryable<vw_AccountDetail>>
        {
            private readonly IAccountDetailRepository _account;
            public ReadAllAccountDetailHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<IQueryable<vw_AccountDetail>> Handle(ReadAllAccountDetail request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._account.GetAccountDetail(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
