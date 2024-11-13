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
    public class CreateNavigationItemCommand : IRequest<GenericResult<NavigationItem>>
    {
        public NavigationItem model { get; set; }

        private class CreateNavigationItemCommandHandler : IRequestHandler<CreateNavigationItemCommand, GenericResult<NavigationItem>>
        {
            private readonly INavigationItemRepository _navigationItem;
            public CreateNavigationItemCommandHandler(INavigationItemRepository navigationItem)
            {
                this._navigationItem = navigationItem;
            }
            public async Task<GenericResult<NavigationItem>> Handle(CreateNavigationItemCommand request, CancellationToken cancellationToken)
            {
                GenericResult<NavigationItem> Result = new GenericResult<NavigationItem>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._navigationItem.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.NavigationItemName} has saved successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while insert record.";
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
