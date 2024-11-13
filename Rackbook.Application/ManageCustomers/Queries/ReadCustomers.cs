using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCustomers.Queries
{
    public class ReadCustomers : IRequest<IQueryable<Customers>>
    {

        public Expression<Func<Customers, bool>>? filter { get; set; }
        public Func<IQueryable<Customers>, IOrderedQueryable<Customers>>? orderBy { get; set; }


        private class ReadCustomersHandler : IRequestHandler<ReadCustomers, IQueryable<Customers>>
        {
            private readonly ICustomersRepository _item;
            public ReadCustomersHandler(ICustomersRepository item)
            {
                this._item = item;
            }
            public async Task<IQueryable<Customers>> Handle(ReadCustomers request, CancellationToken cancellationToken)
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
