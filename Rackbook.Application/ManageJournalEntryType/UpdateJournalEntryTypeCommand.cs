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
    public class UpdateJournalEntryTypeCommand : IRequest<GenericResult<JournalEntryType>>
    {
        public JournalEntryType model { get; set; }

        private class UpdateJournalEntryTypeCommandHandler : IRequestHandler<UpdateJournalEntryTypeCommand, GenericResult<JournalEntryType>>
        {
            private readonly IJournalEntryTypeRepository _journalEntryType;
            public UpdateJournalEntryTypeCommandHandler(IJournalEntryTypeRepository journalEntryType)
            {
                this._journalEntryType = journalEntryType;
            }
            public async Task<GenericResult<JournalEntryType>> Handle(UpdateJournalEntryTypeCommand request, CancellationToken cancellationToken)
            {
                GenericResult<JournalEntryType> Result = new GenericResult<JournalEntryType>();
                try
                {
                    if (request.model is null)
                    {
                        Result.Status = false;
                        Result.Message = "Bad request.";
                    }
                    else
                    {
                        var _Result = await this._journalEntryType.UpdateAsync(request.model);
                        if (_Result is not null)
                        {
                            Result.Data = _Result;
                            Result.Status = true;
                            Result.Message = $"{_Result.JournalEntryTypeName} has updated successfully.";
                        }
                        else
                        {
                            Result.Status = false;
                            Result.Message = $"An error occurred while update record.";
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
