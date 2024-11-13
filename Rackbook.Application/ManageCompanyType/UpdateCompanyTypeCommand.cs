using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCompanyType
{
    public class UpdateCompanyTypeCommand : IRequest<GenericResult<CompanyType>>
    {
        public CompanyType model { get; set; }

        private class UpdateCompanyTypeCommandHandler : IRequestHandler<UpdateCompanyTypeCommand, GenericResult<CompanyType>>
        {
            private readonly ICompanyTypeRepository _companyType;
            public UpdateCompanyTypeCommandHandler(ICompanyTypeRepository companyType)
            {
                this._companyType = companyType;
            }
            public async Task<GenericResult<CompanyType>> Handle(UpdateCompanyTypeCommand request, CancellationToken cancellationToken)
            {
                GenericResult<CompanyType> Result = new GenericResult<CompanyType>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._companyType.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CompanyTypeName} has updated successfully.";
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
