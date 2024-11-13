using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageProvince.Queries
{
    public class GetProvince : IRequest<Province>
    {
        public int Id { get; set; }

        private class GetProvinceHandler : IRequestHandler<GetProvince, Province>
        {
            private readonly IProvinceRepository _province;
            public GetProvinceHandler(IProvinceRepository province)
            {
                this._province = province;
            }
            public async Task<Province> Handle(GetProvince request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._province.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
