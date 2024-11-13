using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageAccountType
{
    public class UpdateAccountTypeCommand : IRequest<GenericResult<AccountType>>
    {
        public AccountType model { get; set; }

        private class UpdateAccountTypeCommandHandler : IRequestHandler<UpdateAccountTypeCommand, GenericResult<AccountType>>
        {
            private readonly IAccountTypeRepository _account;
            public UpdateAccountTypeCommandHandler(IAccountTypeRepository account)
            {
                this._account = account;
            }
            public async Task<GenericResult<AccountType>> Handle(UpdateAccountTypeCommand request, CancellationToken cancellationToken)
            {
                GenericResult<AccountType> Result = new GenericResult<AccountType>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._account.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.AccountTypeName} has updated successfully.";
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
