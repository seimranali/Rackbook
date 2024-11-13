using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageUserRole
{
    public class DeleteUserRoleCommand : IRequest<GenericResult<UserRole>>
    {
        public int Id { get; set; }

        private class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, GenericResult<UserRole>>
        {
            private readonly IUserRoleRepository _userRole;
            public DeleteUserRoleCommandHandler(IUserRoleRepository userRole)
            {
                this._userRole = userRole;
            }
            public async Task<GenericResult<UserRole>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
            {
                GenericResult<UserRole> Result = new GenericResult<UserRole>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._userRole.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.UserRoleName} has deleted successfully.";
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
