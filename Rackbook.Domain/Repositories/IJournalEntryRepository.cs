using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface IJournalEntryRepository : IGenericRepository<JournalEntry, int>
    {

        Task<bool> UpdateStatus(int JournalEntryID, int JournalEntryStatusID, int UserID);
        Task<bool> UpdateAuthorizStatus(int JournalEntryID, int JournalEntryStatusID, int UserID);

    }
}
