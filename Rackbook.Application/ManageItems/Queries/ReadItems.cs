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
    public class ReadItems : IRequest<IQueryable<Items>>
    {

        public Expression<Func<Items, bool>>? filter { get; set; }
        public Func<IQueryable<Items>, IOrderedQueryable<Items>>? orderBy { get; set; }


        private class ReadItemsHandler : IRequestHandler<ReadItems, IQueryable<Items>>
        {
            private readonly IItemsRepository _item;
            public ReadItemsHandler(IItemsRepository item)
            {
                this._item = item;
            }
            public async Task<IQueryable<Items>> Handle(ReadItems request, CancellationToken cancellationToken)
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
