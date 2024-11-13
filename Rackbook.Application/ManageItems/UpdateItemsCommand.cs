using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItems
{
    public class UpdateItemsCommand : IRequest<GenericResult<Items>>
    {
        public Items model { get; set; }

        private class UpdateItemsCommandHandler : IRequestHandler<UpdateItemsCommand, GenericResult<Items>>
        {
            private readonly IItemsRepository _item;
            public UpdateItemsCommandHandler(IItemsRepository item)
            {
                this._item = item;
            }
            public async Task<GenericResult<Items>> Handle(UpdateItemsCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Items> Result = new GenericResult<Items>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._item.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemName} has updated successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while update record.";
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
