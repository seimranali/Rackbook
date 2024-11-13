using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItemUnit.Queries
{
    public class GetItemUnit : IRequest<ItemUnit>
    {
        public int Id { get; set; }

        private class GetItemUnitHandler : IRequestHandler<GetItemUnit, ItemUnit>
        {
            private readonly IItemUnitRepository _itemUnit;
            public GetItemUnitHandler(IItemUnitRepository itemUnit)
            {
                this._itemUnit = itemUnit;
            }
            public async Task<ItemUnit> Handle(GetItemUnit request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._itemUnit.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
