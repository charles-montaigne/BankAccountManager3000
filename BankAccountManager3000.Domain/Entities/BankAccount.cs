using System;

namespace BankAccountManager3000.Domain.Entities
{
    public class BankAccount
    {
        public int Id { get; init; }
        public string BankName { get; init; }
        public string Iban { get; init; }
        public string Bic { get; init; }
        public string HolderName { get; init; }
        public DateTime CreationDate { get; init; }
    }
}