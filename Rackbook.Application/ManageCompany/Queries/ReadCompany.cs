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
    public class ReadCompany : IRequest<IQueryable<Company>>
    {

        public Expression<Func<Company, bool>>? filter { get; set; }
        public Func<IQueryable<Company>, IOrderedQueryable<Company>>? orderBy { get; set; }


        private class ReadCompanyHandler : IRequestHandler<ReadCompany, IQueryable<Company>>
        {
            private readonly ICompanyRepository _company;
            public ReadCompanyHandler(ICompanyRepository company)
            {
                this._company = company;
            }
            public async Task<IQueryable<Company>> Handle(ReadCompany request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._company.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
