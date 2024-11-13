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
    public class DeleteItemsCommand : IRequest<GenericResult<Items>>
    {
        public int Id { get; set; }

        private class DeleteItemsCommandHandler : IRequestHandler<DeleteItemsCommand, GenericResult<Items>>
        {
            private readonly IItemsRepository _item;
            public DeleteItemsCommandHandler(IItemsRepository item)
            {
                this._item = item;
            }
            public async Task<GenericResult<Items>> Handle(DeleteItemsCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Items> Result = new GenericResult<Items>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._item.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ItemName} has deleted successfully.";
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
