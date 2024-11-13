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
    public class DeleteCompanyTypeCommand : IRequest<GenericResult<CompanyType>>
    {
        public int Id { get; set; }

        private class DeleteCompanyTypeCommandHandler : IRequestHandler<DeleteCompanyTypeCommand, GenericResult<CompanyType>>
        {
            private readonly ICompanyTypeRepository _companyType;
            public DeleteCompanyTypeCommandHandler(ICompanyTypeRepository companyType)
            {
                this._companyType = companyType;
            }
            public async Task<GenericResult<CompanyType>> Handle(DeleteCompanyTypeCommand request, CancellationToken cancellationToken)
            {
                GenericResult<CompanyType> Result = new GenericResult<CompanyType>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._companyType.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CompanyTypeName} has deleted successfully.";
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
