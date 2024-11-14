using MediatR;
using Microsoft.EntityFrameworkCore;
using Rackbook.Domain.Models;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageSaleOrder.Queries
{
    public class EditSaleOrder : IRequest<SaleOrderModel>
    {
        public int SaleOrderID { get; set; }

        //Nested Class
        private class EditSaleOrderHandler : IRequestHandler<EditSaleOrder, SaleOrderModel>
        {

            private readonly ISaleOrderMasterRepository _saleOrderMaster;
            private readonly ISaleOrderDetailRepository _saleOrderDetail;
            public EditSaleOrderHandler(ISaleOrderMasterRepository saleOrderMaster, ISaleOrderDetailRepository saleOrderDetail)
            {
                this._saleOrderMaster = saleOrderMaster;
                this._saleOrderDetail = saleOrderDetail;
            }

            public async Task<SaleOrderModel> Handle(EditSaleOrder request, CancellationToken cancellationToken)
            {

                SaleOrderModel model = new SaleOrderModel();
                model.SaleOrderMaster = new Domain.Entities.SaleOrderMaster();
                model.SaleOrderDetails = new List<Domain.Entities.SaleOrderDetail>();
                try
                {

                    if (request.SaleOrderID > 0)
                    {

                        var saleOrder = await this._saleOrderMaster.FindByIDAsync(request.SaleOrderID);
                        var saleOrderDetails = await this._saleOrderDetail.GetAll(x=> x.SaleOrderID == request.SaleOrderID).ToListAsync();


                        model.SaleOrderMaster = saleOrder;
                        model.SaleOrderDetails = saleOrderDetails;
                    }

                    return model;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
