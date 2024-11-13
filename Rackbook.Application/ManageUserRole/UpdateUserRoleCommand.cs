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
    public class UpdateUserRoleCommand : IRequest<GenericResult<UserRole>>
    {
        public UserRole model { get; set; }

        private class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, GenericResult<UserRole>>
        {
            private readonly IUserRoleRepository _userRole;
            public UpdateUserRoleCommandHandler(IUserRoleRepository userRole)
            {
                this._userRole = userRole;
            }
            public async Task<GenericResult<UserRole>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
            {
                GenericResult<UserRole> Result = new GenericResult<UserRole>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._userRole.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.UserRoleName} has updated successfully.";
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
