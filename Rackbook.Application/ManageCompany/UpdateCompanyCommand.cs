using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCompany
{
    public class UpdateCompanyCommand : IRequest<GenericResult<Company>>
    {
        public Company model { get; set; }

        private class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, GenericResult<Company>>
        {
            private readonly ICompanyRepository _company;
            public UpdateCompanyCommandHandler(ICompanyRepository company)
            {
                this._company = company;
            }
            public async Task<GenericResult<Company>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Company> Result = new GenericResult<Company>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._company.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CompanyName} has updated successfully.";
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
