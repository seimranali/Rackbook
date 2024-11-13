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
    public class GetJournalEntryType : IRequest<JournalEntryType>
    {
        public int Id { get; set; }

        private class GetJournalEntryTypeHandler : IRequestHandler<GetJournalEntryType, JournalEntryType>
        {
            private readonly IJournalEntryTypeRepository _journalEntryType;
            public GetJournalEntryTypeHandler(IJournalEntryTypeRepository journalEntryType)
            {
                this._journalEntryType = journalEntryType;
            }
            public async Task<JournalEntryType> Handle(GetJournalEntryType request, CancellationToken cancellationToken)
            {
                try
                {
                    return await this._journalEntryType.FindByIDAsync(request.Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
