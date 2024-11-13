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
    public class ReadAllItems : IRequest<IQueryable<vw_Items>>
    {

        public Expression<Func<vw_Items, bool>>? filter { get; set; }
        public Func<IQueryable<vw_Items>, IOrderedQueryable<vw_Items>>? orderBy { get; set; }


        private class ReadAllItemsHandler : IRequestHandler<ReadAllItems, IQueryable<vw_Items>>
        {
            private readonly IItemsRepository _item;
            public ReadAllItemsHandler(IItemsRepository item)
            {
                this._item = item;
            }
            public async Task<IQueryable<vw_Items>> Handle(ReadAllItems request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._item.GetAllItems(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
