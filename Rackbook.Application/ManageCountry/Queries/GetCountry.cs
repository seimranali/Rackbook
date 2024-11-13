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
    public class GetCountry : IRequest<Country>
    {
        public int Id { get; set; }

        private class GetCountryHandler : IRequestHandler<GetCountry, Country>
        {
            private readonly ICountryRepository _country;
            public GetCountryHandler(ICountryRepository country)
            {
                this._country = country;
            }
            public async Task<Country> Handle(GetCountry request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._country.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
