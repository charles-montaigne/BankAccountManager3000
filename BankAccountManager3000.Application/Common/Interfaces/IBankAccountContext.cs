using BankAccountManager3000.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccountManager3000.Application.Common.Interfaces
{
    public interface IBankAccountContext
    {
        DbSet<BankAccount> BankAccounts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}