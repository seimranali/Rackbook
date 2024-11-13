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
    public class GetCustomersAddress : IRequest<CustomersAddress>
    {
        public int Id { get; set; }

        private class GetCustomersAddressHandler : IRequestHandler<GetCustomersAddress, CustomersAddress>
        {
            private readonly ICustomersAddressRepository _item;
            public GetCustomersAddressHandler(ICustomersAddressRepository item)
            {
                this._item = item;
            }
            public async Task<CustomersAddress> Handle(GetCustomersAddress request, CancellationToken cancellationToken)
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
