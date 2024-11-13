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
    public class UpdateCustomersAddressCommand : IRequest<GenericResult<CustomersAddress>>
    {
        public CustomersAddress model { get; set; }

        private class UpdateCustomersAddressCommandHandler : IRequestHandler<UpdateCustomersAddressCommand, GenericResult<CustomersAddress>>
        {
            private readonly ICustomersAddressRepository _item;
            public UpdateCustomersAddressCommandHandler(ICustomersAddressRepository item)
            {
                this._item = item;
            }
            public async Task<GenericResult<CustomersAddress>> Handle(UpdateCustomersAddressCommand request, CancellationToken cancellationToken)
            {
                GenericResult<CustomersAddress> Result = new GenericResult<CustomersAddress>();
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
                            Result.Message = $"{_Result.BillingAddressLine1} has updated successfully.";
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
