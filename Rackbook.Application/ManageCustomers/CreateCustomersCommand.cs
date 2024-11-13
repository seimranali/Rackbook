using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Models;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCustomers
{
    public class CreateCustomersCommand : IRequest<GenericResult<Customers>>
    {
        public CustomersModel model { get; set; }

        private class CreateCustomersCommandHandler : IRequestHandler<CreateCustomersCommand, GenericResult<Customers>>
        {
            private readonly ICustomersRepository _customers;
            private readonly ICustomersAddressRepository _customersAddress;
            public CreateCustomersCommandHandler(ICustomersRepository customers, ICustomersAddressRepository customersAddress)
            {
                this._customers = customers;
                this._customersAddress = customersAddress;
            }
            public async Task<GenericResult<Customers>> Handle(CreateCustomersCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Customers> Result = new GenericResult<Customers>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._customers.AddAsync(request.model.Customers);
                        if (_Result is not null)
                        {
                            if (request.model.CustomersAddress is not null)
                            {
                                request.model.CustomersAddress.CustomerID = _Result.CustomerID;
                                await this._customersAddress.AddAsync(request.model.CustomersAddress);
                            }

                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CustomerName} has saved successfully.";
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
