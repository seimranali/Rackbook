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
    public class DeleteUsersCommand : IRequest<GenericResult<Users>>
    {
        public int Id { get; set; }

        private class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, GenericResult<Users>>
        {
            private readonly IUsersRepository _users;
            public DeleteUsersCommandHandler(IUsersRepository users)
            {
                this._users = users;
            }
            public async Task<GenericResult<Users>> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Users> Result = new GenericResult<Users>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._users.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.UserName} has deleted successfully.";
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
