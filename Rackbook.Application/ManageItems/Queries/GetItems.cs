using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItems.Queries
{
    public class GetItems : IRequest<Items>
    {
        public int Id { get; set; }

        private class GetItemsHandler : IRequestHandler<GetItems, Items>
        {
            private readonly IItemsRepository _item;
            public GetItemsHandler(IItemsRepository item)
            {
                this._item = item;
            }
            public async Task<Items> Handle(GetItems request, CancellationToken cancellationToken)
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
