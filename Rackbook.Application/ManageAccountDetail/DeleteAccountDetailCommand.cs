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
    public class DeleteAccountDetailCommand : IRequest<GenericResult<AccountDetail>>
    {
        public int Id { get; set; }

        private class DeleteAccountDetailCommandHandler : IRequestHandler<DeleteAccountDetailCommand, GenericResult<AccountDetail>>
        {
            private readonly IAccountDetailRepository _account;
            public DeleteAccountDetailCommandHandler(IAccountDetailRepository account)
            {
                this._account = account;
            }
            public async Task<GenericResult<AccountDetail>> Handle(DeleteAccountDetailCommand request, CancellationToken cancellationToken)
            {
                GenericResult<AccountDetail> Result = new GenericResult<AccountDetail>();
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
                            Result.Message = $"{_Result.AccountName} has deleted successfully.";
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
