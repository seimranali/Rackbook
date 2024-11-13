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
    public class CreateAccountTypeCommand : IRequest<GenericResult<AccountType>>
    {
        public AccountType model { get; set; }

        private class CreateAccountTypeCommandHandler : IRequestHandler<CreateAccountTypeCommand, GenericResult<AccountType>>
        {
            private readonly IAccountTypeRepository _account;
            public CreateAccountTypeCommandHandler(IAccountTypeRepository account)
            {
                this._account = account;
            }
            public async Task<GenericResult<AccountType>> Handle(CreateAccountTypeCommand request, CancellationToken cancellationToken)
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
                        var _Result = await this._account.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.AccountTypeName} has saved successfully.";
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
