using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageAccountDetail
{
    public class CreateAccountDetailCommand : IRequest<GenericResult<AccountDetail>>
    {
        public AccountDetail model { get; set; }

        private class CreateAccountDetailCommandHandler : IRequestHandler<CreateAccountDetailCommand, GenericResult<AccountDetail>>
        {
            private readonly IAccountDetailRepository _account;
            public CreateAccountDetailCommandHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<GenericResult<AccountDetail>> Handle(CreateAccountDetailCommand request, CancellationToken cancellationToken)
            {
                GenericResult<AccountDetail> Result = new GenericResult<AccountDetail>();
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
                            Result.Message = $"{_Result.AccountName} has saved successfully.";
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
