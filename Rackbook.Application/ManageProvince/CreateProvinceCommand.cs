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
    public class CreateProvinceCommand : IRequest<GenericResult<Province>>
    {
        public Province model { get; set; }

        private class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, GenericResult<Province>>
        {
            private readonly IProvinceRepository _province;
            public CreateProvinceCommandHandler(IProvinceRepository province)
            {
                this._province = province;
            }
            public async Task<GenericResult<Province>> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Province> Result = new GenericResult<Province>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._province.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.ProvinceName} has saved successfully.";
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
