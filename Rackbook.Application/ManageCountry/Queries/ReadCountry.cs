using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageCountry.Queries
{
    public class ReadCountry : IRequest<IQueryable<Country>>
    {

        public Expression<Func<Country, bool>>? filter { get; set; }
        public Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy { get; set; }


        private class ReadCountryHandler : IRequestHandler<ReadCountry, IQueryable<Country>>
        {
            private readonly ICountryRepository _country;
            public ReadCountryHandler(ICountryRepository country)
            {
                this._country = country;
            }
            public async Task<IQueryable<Country>> Handle(ReadCountry request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._country.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
