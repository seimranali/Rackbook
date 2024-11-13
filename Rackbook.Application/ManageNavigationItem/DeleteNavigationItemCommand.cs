using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageNavigationItem
{
    public class DeleteNavigationItemCommand : IRequest<GenericResult<NavigationItem>>
    {
        public int Id { get; set; }

        private class DeleteNavigationItemCommandHandler : IRequestHandler<DeleteNavigationItemCommand, GenericResult<NavigationItem>>
        {
            private readonly INavigationItemRepository _navigationItem;
            public DeleteNavigationItemCommandHandler(INavigationItemRepository navigationItem)
            {
                this._navigationItem = navigationItem;
            }
            public async Task<GenericResult<NavigationItem>> Handle(DeleteNavigationItemCommand request, CancellationToken cancellationToken)
            {
                GenericResult<NavigationItem> Result = new GenericResult<NavigationItem>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._navigationItem.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.NavigationItemName} has deleted successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while delete record.";
                        }
                    }

                    return Result;
                }
                catch (Exception ex)
                {
                    Result.Status = false;
                    Result.Message = ex.Message;
                    return Result;
                }
            }
        }
    }
}
