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
    public class CreateItemGroupCommand : IRequest<GenericResult<ItemGroup>>
    {
        public ItemGroup model { get; set; }

        private class CreateItemGroupCommandHandler : IRequestHandler<CreateItemGroupCommand, GenericResult<ItemGroup>>
        {
            private readonly IItemGroupRepository _itemGroup;
            public CreateItemGroupCommandHandler(IItemGroupRepository itemGroup)
            {
                this._itemGroup = itemGroup;
            }
            public async Task<GenericResult<ItemGroup>> Handle(CreateItemGroupCommand request, CancellationToken cancellationToken)
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
                        var _Result = await this._itemGroup.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemGroupName} has saved successfully.";
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
