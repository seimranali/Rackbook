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
    public class GetNavigationItem : IRequest<NavigationItem>
    {
        public int Id { get; set; }

        private class GetNavigationItemHandler : IRequestHandler<GetNavigationItem, NavigationItem>
        {
            private readonly INavigationItemRepository _navigationItem;
            public GetNavigationItemHandler(INavigationItemRepository navigationItem)
            {
                this._navigationItem = navigationItem;
            }
            public async Task<NavigationItem> Handle(GetNavigationItem request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._navigationItem.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
