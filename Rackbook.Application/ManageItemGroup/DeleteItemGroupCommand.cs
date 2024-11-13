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
    public class DeleteItemGroupCommand : IRequest<GenericResult<ItemGroup>>
    {
        public int Id { get; set; }

        private class DeleteItemGroupCommandHandler : IRequestHandler<DeleteItemGroupCommand, GenericResult<ItemGroup>>
        {
            private readonly IItemGroupRepository _itemGroup;
            public DeleteItemGroupCommandHandler(IItemGroupRepository itemGroup)
            {
                this._itemGroup = itemGroup;
            }
            public async Task<GenericResult<ItemGroup>> Handle(DeleteItemGroupCommand request, CancellationToken cancellationToken)
            {
                GenericResult<ItemGroup> Result = new GenericResult<ItemGroup>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._itemGroup.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemGroupName} has deleted successfully.";
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
