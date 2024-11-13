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
    public class ReadCompanyType : IRequest<IQueryable<CompanyType>>
    {

        public Expression<Func<CompanyType, bool>>? filter { get; set; }
        public Func<IQueryable<CompanyType>, IOrderedQueryable<CompanyType>>? orderBy { get; set; }


        private class ReadCompanyTypeHandler : IRequestHandler<ReadCompanyType, IQueryable<CompanyType>>
        {
            private readonly ICompanyTypeRepository _companyType;
            public ReadCompanyTypeHandler(ICompanyTypeRepository companyType)
            {
                this._companyType = companyType;
            }
            public async Task<IQueryable<CompanyType>> Handle(ReadCompanyType request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._companyType.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
