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
    public class ReadNavigationItem : IRequest<IQueryable<NavigationItem>>
    {

        public Expression<Func<NavigationItem, bool>>? filter { get; set; }
        public Func<IQueryable<NavigationItem>, IOrderedQueryable<NavigationItem>>? orderBy { get; set; }


        private class ReadNavigationItemHandler : IRequestHandler<ReadNavigationItem, IQueryable<NavigationItem>>
        {
            private readonly INavigationItemRepository _navigationItem;
            public ReadNavigationItemHandler(INavigationItemRepository navigationItem)
            {
                this._navigationItem = navigationItem;
            }
            public async Task<IQueryable<NavigationItem>> Handle(ReadNavigationItem request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._navigationItem.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
