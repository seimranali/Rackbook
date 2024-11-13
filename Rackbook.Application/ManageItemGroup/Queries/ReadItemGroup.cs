using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItemGroup.Queries
{
    public class ReadItemGroup : IRequest<IQueryable<ItemGroup>>
    {

        public Expression<Func<ItemGroup, bool>>? filter { get; set; }
        public Func<IQueryable<ItemGroup>, IOrderedQueryable<ItemGroup>>? orderBy { get; set; }


        private class ReadItemGroupHandler : IRequestHandler<ReadItemGroup, IQueryable<ItemGroup>>
        {
            private readonly IItemGroupRepository _itemGroup;
            public ReadItemGroupHandler(IItemGroupRepository itemGroup)
            {
                this._itemGroup = itemGroup;
            }
            public async Task<IQueryable<ItemGroup>> Handle(ReadItemGroup request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._itemGroup.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
