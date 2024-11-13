using MediatR;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Rackbook.Application.Behaviors
{
    public class UnitofWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUnitofWork _unitofWork;
        public UnitofWorkBehavior(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (NotCommand())
            {
                return await next();
            }

            using var trans = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted },
                    TransactionScopeAsyncFlowOption.Enabled);

            var response = await next();

            await this._unitofWork.SaveChangesAsync(cancellationToken);

            trans.Complete();

            return response;

        }

        private bool NotCommand()
        {
            return !typeof(TRequest).Name.EndsWith("Command");
        }
    }

}
