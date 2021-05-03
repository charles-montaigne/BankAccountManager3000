using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankAccountManager3000.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManager3000.Application.Common.Interfaces
{
    public interface IBankAccountContext
    {
        DbSet<BankAccount> BankAccounts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
