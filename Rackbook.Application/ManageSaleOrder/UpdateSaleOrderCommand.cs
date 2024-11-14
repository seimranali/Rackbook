using MediatR;
using Microsoft.EntityFrameworkCore;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Models;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageSaleOrder
{
    public class UpdateSaleOrderCommand : IRequest<GenericResult<SaleOrderMaster>>
    {
        public SaleOrderModel model { get; set; }

        //Nasted Class
        //IRequestHandler<TReuest, TResponse>     
        private class UpdateSaleOrderCommandHandler : IRequestHandler<UpdateSaleOrderCommand, GenericResult<SaleOrderMaster>>
        {
            private readonly ISaleOrderMasterRepository _saleOrderMaster;
            private readonly ISaleOrderDetailRepository _saleOrderDetail;
            public UpdateSaleOrderCommandHandler(ISaleOrderMasterRepository saleOrderMaster, ISaleOrderDetailRepository saleOrderDetail)
            {
                this._saleOrderMaster = saleOrderMaster;
                this._saleOrderDetail = saleOrderDetail;
            }


            public async Task<GenericResult<SaleOrderMaster>> Handle(UpdateSaleOrderCommand request, CancellationToken cancellationToken)
            {

                GenericResult<SaleOrderMaster> Result = new GenericResult<SaleOrderMaster>();
                Result.Data = new SaleOrderMaster();

                try
                {
                    if (request.model is not null)
                    {


                        //Delete Privios Record from SaleOrderDetail Table


                        var saleOrderDetails = await this._saleOrderDetail.GetAll(x=> x.SaleOrderID == request.model.SaleOrderMaster.SaleOrderID).ToListAsync();

                        if (saleOrderDetails is not null && saleOrderDetails.Count > 0)
                            await this._saleOrderDetail.RemoveRangeAsync(saleOrderDetails);



                        var saleOrder =await this._saleOrderMaster.UpdateAsync(request.model.SaleOrderMaster);

                        if (saleOrder is not null)
                        {
                            //Assign Latest SaleOrderID 
                            request.model.SaleOrderDetails.ForEach(x => x.SaleOrderID = saleOrder.SaleOrderID);
                            await this._saleOrderDetail.AddRangeAsync(request.model.SaleOrderDetails);



                            Result.Data = saleOrder;
                            Result.Status = true;
                            Result.Message = $"Sale order {saleOrder.SaleOrderNumber} has been updated successfully";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"Sale order {saleOrder.SaleOrderNumber} has not been updated successfully";
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
