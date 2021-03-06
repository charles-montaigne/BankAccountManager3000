using MediatR;

namespace BankAccountManager3000.Application.BankAccounts.Commands.AddBankAccount
{
    public class AddBankAccountCommand : IRequest<AddBankAccountResponse>
    {
        public string BankName { get; init; }
        public string Iban { get; init; }
        public string Bic { get; init; }
        public string HolderName { get; init; }
    }
}