using BankAccountManager3000.Application.Common.Interfaces;
using BankAccountManager3000.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccountManager3000.Infrastructure
{
    public class BankAccountContext : DbContext, IBankAccountContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasAlternateKey(x => x.Iban);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Filename=../BankAccountData.sqlite");
        }
    }
}