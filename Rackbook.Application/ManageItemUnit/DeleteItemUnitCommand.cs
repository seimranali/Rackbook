using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItemUnit
{
    public class DeleteItemUnitCommand : IRequest<GenericResult<ItemUnit>>
    {
        public int Id { get; set; }

        private class DeleteItemUnitCommandHandler : IRequestHandler<DeleteItemUnitCommand, GenericResult<ItemUnit>>
        {
            private readonly IItemUnitRepository _itemUnit;
            public DeleteItemUnitCommandHandler(IItemUnitRepository itemUnit)
            {
                this._itemUnit = itemUnit;
            }
            public async Task<GenericResult<ItemUnit>> Handle(DeleteItemUnitCommand request, CancellationToken cancellationToken)
            {
                GenericResult<ItemUnit> Result = new GenericResult<ItemUnit>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._itemUnit.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemUnitName} has deleted successfully.";
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
