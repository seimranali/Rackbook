using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCustomersAddress
{
    public class DeleteCustomersAddressCommand : IRequest<GenericResult<CustomersAddress>>
    {
        public int Id { get; set; }

        private class DeleteCustomersAddressCommandHandler : IRequestHandler<DeleteCustomersAddressCommand, GenericResult<CustomersAddress>>
        {
            private readonly ICustomersAddressRepository _item;
            public DeleteCustomersAddressCommandHandler(ICustomersAddressRepository item)
            {
                this._item = item;
            }
            public async Task<GenericResult<CustomersAddress>> Handle(DeleteCustomersAddressCommand request, CancellationToken cancellationToken)
            {
                GenericResult<CustomersAddress> Result = new GenericResult<CustomersAddress>();
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
                            Result.Message = $"{_Result.BillingAddressLine1} has deleted successfully.";
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
