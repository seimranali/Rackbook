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
    public class ReadProvince : IRequest<IQueryable<Province>>
    {

        public Expression<Func<Province, bool>>? filter { get; set; }
        public Func<IQueryable<Province>, IOrderedQueryable<Province>>? orderBy { get; set; }


        private class ReadProvinceHandler : IRequestHandler<ReadProvince, IQueryable<Province>>
        {
            private readonly IProvinceRepository _province;
            public ReadProvinceHandler(IProvinceRepository province)
            {
                this._province = province;
            }
            public async Task<IQueryable<Province>> Handle(ReadProvince request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._province.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
