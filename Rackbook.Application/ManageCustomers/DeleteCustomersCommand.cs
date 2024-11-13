using MediatR;
using Microsoft.EntityFrameworkCore;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCustomers
{
    public class DeleteCustomersCommand : IRequest<GenericResult<Customers>>
    {
        public int Id { get; set; }

        private class DeleteCustomersCommandHandler : IRequestHandler<DeleteCustomersCommand, GenericResult<Customers>>
        {
            private readonly ICustomersRepository _customers;
            private readonly ICustomersAddressRepository _customersAddress;
            public DeleteCustomersCommandHandler(ICustomersRepository customers, ICustomersAddressRepository customersAddress)
            {
                this._customers = customers;
                this._customersAddress = customersAddress;
            }
            public async Task<GenericResult<Customers>> Handle(DeleteCustomersCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Customers> Result = new GenericResult<Customers>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {

                        var customerAdd = await this._customersAddress.GetAll(x => x.CustomerID == request.Id).FirstOrDefaultAsync();
                        if (customerAdd is not null)
                        {
                            await this._customersAddress.DeleteAsync(customerAdd.CustomerAddressID);
                        }

                        var _Result = await this._customers.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CustomerName} has deleted successfully.";
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
