using MediatR;
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
    public class CreateSaleOrderCommand : IRequest<GenericResult<SaleOrderMaster>>
    {

        public SaleOrderModel model { get; set; }

        public class CreateSaleOrderCommandHandler : IRequestHandler<CreateSaleOrderCommand, GenericResult<SaleOrderMaster>>
        {
            private readonly ISaleOrderMasterRepository _saleOrderMaster;
            private readonly ISaleOrderDetailRepository _saleOrderDetail;
            public CreateSaleOrderCommandHandler(ISaleOrderMasterRepository saleOrderMaster,
                ISaleOrderDetailRepository saleOrderDetail)
            {

                this._saleOrderMaster = saleOrderMaster;
                this._saleOrderDetail = saleOrderDetail;

            }
            public async Task<GenericResult<SaleOrderMaster>> Handle(CreateSaleOrderCommand request, CancellationToken cancellationToken)
            {
                GenericResult<SaleOrderMaster> Result = new GenericResult<SaleOrderMaster>();
                Result.Data = new SaleOrderMaster();
                try
                {
                    if (request.model is not null)
                    {

                        if (request.model.SaleOrderMaster is not null)
                        {

                            var saleOrder = await this._saleOrderMaster.AddAsync(request.model.SaleOrderMaster);
                            if (saleOrder is not null)
                            {
                                //Assign Lastest SaleOrderID
                                request.model.SaleOrderDetails.ForEach(x => { x.SaleOrderID = saleOrder.SaleOrderID; });
                                await this._saleOrderDetail.AddRangeAsync(request.model.SaleOrderDetails);

                                Result.Data = saleOrder;
                                Result.Status = true;
                                Result.Message = $"Sale order {saleOrder.SaleOrderNumber} has been saved successfully";

                            }
                            else
                            {
                                Result.Status = false;
                                Result.Message = $"Sale order {saleOrder.SaleOrderNumber} has not been saved successfully";
                            }
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"Data is not provided";
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

                    throw;
                }
            }
        }
    }
}
