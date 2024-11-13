﻿using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageItemUnit
{
    public class CreateItemUnitCommand : IRequest<GenericResult<ItemUnit>>
    {
        public ItemUnit model { get; set; }

        private class CreateItemUnitCommandHandler : IRequestHandler<CreateItemUnitCommand, GenericResult<ItemUnit>>
        {
            private readonly IItemUnitRepository _itemUnit;
            public CreateItemUnitCommandHandler(IItemUnitRepository itemUnit)
            {
                this._itemUnit = itemUnit;
            }
            public async Task<GenericResult<ItemUnit>> Handle(CreateItemUnitCommand request, CancellationToken cancellationToken)
            {
                GenericResult<ItemUnit> Result = new GenericResult<ItemUnit>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._itemUnit.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemUnitName} has saved successfully.";
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
