﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Domain.Repositories
{
    public interface IUnitofWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
