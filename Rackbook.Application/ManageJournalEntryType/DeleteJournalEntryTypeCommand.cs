using MediatR;
using Rackbook.Domain.Entities;
using Rackbook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Application.ManageJournalEntryType
{
    public class DeleteJournalEntryTypeCommand : IRequest<GenericResult<JournalEntryType>>
    {
        public int Id { get; set; }

        private class DeleteJournalEntryTypeCommandHandler : IRequestHandler<DeleteJournalEntryTypeCommand, GenericResult<JournalEntryType>>
        {
            private readonly IJournalEntryTypeRepository _journalEntryType;
            public DeleteJournalEntryTypeCommandHandler(IJournalEntryTypeRepository journalEntryType)
            {
                this._journalEntryType = journalEntryType;
            }
            public async Task<GenericResult<JournalEntryType>> Handle(DeleteJournalEntryTypeCommand request, CancellationToken cancellationToken)
            {
                GenericResult<JournalEntryType> Result = new GenericResult<JournalEntryType>();
                try
                {
                    if (request.Id <= 0)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._journalEntryType.DeleteAsync(request.Id);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.JournalEntryTypeName} has deleted successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while delete record.";
                        }
                    }

                    return Result;
                }
                catch (Exception ex)
                {
                    Result.Status = false;
                    Result.Message = ex.Message;
                    return Result;
                }
            }
        }
    }
}
