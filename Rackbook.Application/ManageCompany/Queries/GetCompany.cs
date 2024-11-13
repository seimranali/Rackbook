using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCompany.Queries
{
    public class GetCompany : IRequest<Company>
    {
        public int Id { get; set; }

        private class GetCompanyHandler : IRequestHandler<GetCompany, Company>
        {
            private readonly ICompanyRepository _company;
            public GetCompanyHandler(ICompanyRepository company)
            {
                this._company = company;
            }
            public async Task<Company> Handle(GetCompany request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._company.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
