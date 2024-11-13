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
    public class CreateCompanyTypeCommand : IRequest<GenericResult<CompanyType>>
    {
        public CompanyType model { get; set; }

        private class CreateCompanyTypeCommandHandler : IRequestHandler<CreateCompanyTypeCommand, GenericResult<CompanyType>>
        {
            private readonly ICompanyTypeRepository _companyType;
            public CreateCompanyTypeCommandHandler(ICompanyTypeRepository companyType)
            {
                this._companyType = companyType;
            }
            public async Task<GenericResult<CompanyType>> Handle(CreateCompanyTypeCommand request, CancellationToken cancellationToken)
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
                        var _Result = await this._companyType.AddAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CompanyTypeName} has saved successfully.";
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
