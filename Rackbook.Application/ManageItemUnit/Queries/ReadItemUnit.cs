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
    public class ReadItemUnit : IRequest<IQueryable<ItemUnit>>
    {

        public Expression<Func<ItemUnit, bool>>? filter { get; set; }
        public Func<IQueryable<ItemUnit>, IOrderedQueryable<ItemUnit>>? orderBy { get; set; }


        private class ReadItemUnitHandler : IRequestHandler<ReadItemUnit, IQueryable<ItemUnit>>
        {
            private readonly IItemUnitRepository _itemUnit;
            public ReadItemUnitHandler(IItemUnitRepository itemUnit)
            {
                this._itemUnit = itemUnit;
            }
            public async Task<IQueryable<ItemUnit>> Handle(ReadItemUnit request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._itemUnit.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
