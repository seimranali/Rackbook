using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageSaleOrder.Queries
{
    public class ReadAllSaleOrder : IRequest<IQueryable<SaleOrderMaster>>
    {
        public Expression<Func<SaleOrderMaster, bool>>? filter { get; set; } = default;
        public Func<IQueryable<SaleOrderMaster>, IOrderedQueryable<SaleOrderMaster>>? orderBy { get; set; } = default;

        private class ReadAllSaleOrderHandler : IRequestHandler<ReadAllSaleOrder, IQueryable<SaleOrderMaster>>
        {
            private readonly ISaleOrderMasterRepository _saleOrderMaster;
            public ReadAllSaleOrderHandler(ISaleOrderMasterRepository saleOrderMaster)
            {
                this._saleOrderMaster = saleOrderMaster;
            }

            public async Task<IQueryable<SaleOrderMaster>> Handle(ReadAllSaleOrder request, CancellationToken cancellationToken)
            {
                try
                {


                    IQueryable<SaleOrderMaster> query = this._saleOrderMaster.GetAll(request.filter, request.orderBy);

                    return query;

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
