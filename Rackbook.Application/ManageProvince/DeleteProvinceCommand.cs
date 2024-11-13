using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageProvince
{
    public class DeleteProvinceCommand : IRequest<GenericResult<Province>>
    {
        public int Id { get; set; }

        private class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, GenericResult<Province>>
        {
            private readonly IProvinceRepository _province;
            public DeleteProvinceCommandHandler(IProvinceRepository province)
            {
                this._province = province;
            }
            public async Task<GenericResult<Province>> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Province> Result = new GenericResult<Province>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._province.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ProvinceName} has deleted successfully.";
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
