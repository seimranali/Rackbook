using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageNavigationItem.Queries
{
    public class ReadAllNavigationItem : IRequest<NavigationItem[]>
    {

        public Expression<Func<NavigationItem, bool>>? filter { get; set; }
        public Func<IQueryable<NavigationItem>, IOrderedQueryable<NavigationItem>>? orderBy { get; set; }


        private class ReadAllNavigationItemHandler : IRequestHandler<ReadAllNavigationItem, NavigationItem[]>
        {
            private readonly INavigationItemRepository _navigationItem;
            public ReadAllNavigationItemHandler(INavigationItemRepository navigationItem)
            {
                this._navigationItem = navigationItem;
            }
            public async Task<NavigationItem[]> Handle(ReadAllNavigationItem request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._navigationItem.GetNavigationItems(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
