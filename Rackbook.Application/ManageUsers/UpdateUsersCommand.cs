using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageUsers
{
    public class UpdateUsersCommand : IRequest<GenericResult<Users>>
    {
        public Users model { get; set; }

        private class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, GenericResult<Users>>
        {
            private readonly IUsersRepository _users;
            public UpdateUsersCommandHandler(IUsersRepository users)
            {
                this._users = users;
            }
            public async Task<GenericResult<Users>> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Users> Result = new GenericResult<Users>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._users.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.UserName} has updated successfully.";
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
