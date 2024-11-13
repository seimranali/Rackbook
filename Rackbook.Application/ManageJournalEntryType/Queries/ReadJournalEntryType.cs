using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageJournalEntryType.Queries
{
    public class ReadJournalEntryType : IRequest<IQueryable<JournalEntryType>>
    {

        public Expression<Func<JournalEntryType, bool>>? filter { get; set; }
        public Func<IQueryable<JournalEntryType>, IOrderedQueryable<JournalEntryType>>? orderBy { get; set; }


        private class ReadJournalEntryTypeHandler : IRequestHandler<ReadJournalEntryType, IQueryable<JournalEntryType>>
        {
            private readonly IJournalEntryTypeRepository _journalEntryType;
            public ReadJournalEntryTypeHandler(IJournalEntryTypeRepository journalEntryType)
            {
                this._journalEntryType = journalEntryType;
            }
            public async Task<IQueryable<JournalEntryType>> Handle(ReadJournalEntryType request, CancellationToken cancellationToken)
            {
                try
                {
                    return this._journalEntryType.GetAll(request.filter, request.orderBy);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
