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
    public class GetItemGroup : IRequest<ItemGroup>
    {
        public int Id { get; set; }

        private class GetItemGroupHandler : IRequestHandler<GetItemGroup, ItemGroup>
        {
            private readonly IItemGroupRepository _itemGroup;
            public GetItemGroupHandler(IItemGroupRepository itemGroup)
            {
                this._itemGroup = itemGroup;
            }
            public async Task<ItemGroup> Handle(GetItemGroup request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._itemGroup.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
