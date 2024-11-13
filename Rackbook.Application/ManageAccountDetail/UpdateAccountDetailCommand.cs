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
    public class UpdateAccountDetailCommand : IRequest<GenericResult<AccountDetail>>
    {
        public AccountDetail model { get; set; }

        private class UpdateAccountDetailCommandHandler : IRequestHandler<UpdateAccountDetailCommand, GenericResult<AccountDetail>>
        {
            private readonly IAccountDetailRepository _account;
            public UpdateAccountDetailCommandHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<GenericResult<AccountDetail>> Handle(UpdateAccountDetailCommand request, CancellationToken cancellationToken)
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
                        var _Result = await this._account.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.AccountName} has updated successfully.";
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
