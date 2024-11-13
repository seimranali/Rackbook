using Rackbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company, int>
    {

        Task<bool> UpdateCompanyStatus(int CompanyID, bool IsActive);
    }
}
