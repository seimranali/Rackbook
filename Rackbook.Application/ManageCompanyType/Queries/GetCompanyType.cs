using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCompanyType.Queries
{
    public class GetCompanyType : IRequest<CompanyType>
    {
        public int Id { get; set; }

        private class GetCompanyTypeHandler : IRequestHandler<GetCompanyType, CompanyType>
        {
            private readonly ICompanyTypeRepository _companyType;
            public GetCompanyTypeHandler(ICompanyTypeRepository companyType)
            {
                this._companyType = companyType;
            }
            public async Task<CompanyType> Handle(GetCompanyType request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._companyType.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
