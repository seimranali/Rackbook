using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItemGroup
{
    public class UpdateItemGroupCommand : IRequest<GenericResult<ItemGroup>>
    {
        public ItemGroup model { get; set; }

        private class UpdateItemGroupCommandHandler : IRequestHandler<UpdateItemGroupCommand, GenericResult<ItemGroup>>
        {
            private readonly IItemGroupRepository _itemGroup;
            public UpdateItemGroupCommandHandler(IItemGroupRepository itemGroup)
            {
                this._itemGroup = itemGroup;
            }
            public async Task<GenericResult<ItemGroup>> Handle(UpdateItemGroupCommand request, CancellationToken cancellationToken)
            {
                GenericResult<ItemGroup> Result = new GenericResult<ItemGroup>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._itemGroup.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemGroupName} has updated successfully.";
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
