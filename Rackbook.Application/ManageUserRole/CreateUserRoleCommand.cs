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
    public class CreateUserRoleCommand : IRequest<GenericResult<UserRole>>
    {
        public UserRole model { get; set; }

        private class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, GenericResult<UserRole>>
        {
            private readonly IUserRoleRepository _userRole;
            public CreateUserRoleCommandHandler(IUserRoleRepository userRole)
            {
                this._userRole = userRole;
            }
            public async Task<GenericResult<UserRole>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
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
                        var _Result = await this._userRole.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.UserRoleName} has saved successfully.";
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
