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
    public class GetCustomers : IRequest<Customers>
    {
        public int Id { get; set; }

        private class GetCustomersHandler : IRequestHandler<GetCustomers, Customers>
        {
            private readonly ICustomersRepository _item;
            public GetCustomersHandler(ICustomersRepository item)
            {
                this._item = item;
            }
            public async Task<Customers> Handle(GetCustomers request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._item.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
