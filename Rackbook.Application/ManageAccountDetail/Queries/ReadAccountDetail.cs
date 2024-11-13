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
    public class ReadAccountDetail : IRequest<IQueryable<AccountDetail>>
    {

        public Expression<Func<AccountDetail, bool>>? filter { get; set; }
        public Func<IQueryable<AccountDetail>, IOrderedQueryable<AccountDetail>>? orderBy { get; set; }


        private class ReadAccountDetailHandler : IRequestHandler<ReadAccountDetail, IQueryable<AccountDetail>>
        {
            private readonly IAccountDetailRepository _account;
            public ReadAccountDetailHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<IQueryable<AccountDetail>> Handle(ReadAccountDetail request, CancellationToken cancellationToken)
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
