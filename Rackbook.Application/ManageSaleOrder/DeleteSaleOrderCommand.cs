using MediatR;
using Microsoft.EntityFrameworkCore;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageSaleOrder
{
    public class DeleteSaleOrderCommand : IRequest<GenericResult<SaleOrderMaster>>
    {
        //Property Sale Order ID
        public int SaleOrderID { get; set; }

        //Nasted Class
        private class DeleteSaleOrderCommandHandler : IRequestHandler<DeleteSaleOrderCommand, GenericResult<SaleOrderMaster>>
        {

            //Constractor
            private readonly ISaleOrderMasterRepository _saleOrderMaster;
            private readonly ISaleOrderDetailRepository _saleOrderDetail;
            public DeleteSaleOrderCommandHandler(ISaleOrderMasterRepository saleOrderMaster,
                ISaleOrderDetailRepository saleOrderDetail)
            {

                this._saleOrderMaster = saleOrderMaster;
                this._saleOrderDetail = saleOrderDetail;
            }

            public async Task<GenericResult<SaleOrderMaster>> Handle(DeleteSaleOrderCommand request, CancellationToken cancellationToken)
            {

                GenericResult<SaleOrderMaster> Result = new GenericResult<SaleOrderMaster>();
                Result.Data = new SaleOrderMaster();
                try
                {


                    if(request.SaleOrderID > 0)
                    {

                        var saleOrderDetails = await this._saleOrderDetail.GetAll(x=> x.SaleOrderID == request.SaleOrderID).ToListAsync();
                        if (saleOrderDetails is not null && saleOrderDetails.Count > 0)
                            await this._saleOrderDetail.RemoveRangeAsync(saleOrderDetails);


                        var saleOrder = await this._saleOrderMaster.DeleteAsync(request.SaleOrderID);

                        if(saleOrder is not null)
                        {


                            Result.Data = saleOrder;
                            Result.Status = true;
                            Result.Message = $"Sale order {saleOrder.SaleOrderNumber} has been deleted successfully";


                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"Sale order has not been deleted successfully";

                        }
                    }
                    else
                    {
                        Result.Status = false;
                        Result.Message = $"Data is not provided";

                    }
                    return Result;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
