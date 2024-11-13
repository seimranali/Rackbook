using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCustomersAddress.Queries
{
    public class ReadCustomersAddress : IRequest<IQueryable<CustomersAddress>>
    {

        public Expression<Func<CustomersAddress, bool>>? filter { get; set; }
        public Func<IQueryable<CustomersAddress>, IOrderedQueryable<CustomersAddress>>? orderBy { get; set; }


        private class ReadCustomersAddressHandler : IRequestHandler<ReadCustomersAddress, IQueryable<CustomersAddress>>
        {
            private readonly ICustomersAddressRepository _item;
            public ReadCustomersAddressHandler(ICustomersAddressRepository item)
            {
                this._item = item;
            }
            public async Task<IQueryable<CustomersAddress>> Handle(ReadCustomersAddress request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._item.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
