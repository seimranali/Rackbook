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
    public class DeleteCompanyCommand : IRequest<GenericResult<Company>>
    {
        public int Id { get; set; }

        private class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, GenericResult<Company>>
        {
            private readonly ICompanyRepository _company;
            public DeleteCompanyCommandHandler(ICompanyRepository company)
            {
                this._company = company;
            }
            public async Task<GenericResult<Company>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {
                GenericResult<Company> Result = new GenericResult<Company>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._company.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.CompanyName} has deleted successfully.";
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
