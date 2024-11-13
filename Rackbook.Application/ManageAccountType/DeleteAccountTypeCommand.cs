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
    public class DeleteAccountTypeCommand : IRequest<GenericResult<AccountType>>
    {
        public int Id { get; set; }

        private class DeleteAccountTypeCommandHandler : IRequestHandler<DeleteAccountTypeCommand, GenericResult<AccountType>>
        {
            private readonly IAccountTypeRepository _account;
            public DeleteAccountTypeCommandHandler(IAccountTypeRepository account)
            {
                this._account = account;
            }
            public async Task<GenericResult<AccountType>> Handle(DeleteAccountTypeCommand request, CancellationToken cancellationToken)
            {
                GenericResult<AccountType> Result = new GenericResult<AccountType>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._account.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.AccountTypeName} has deleted successfully.";
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
