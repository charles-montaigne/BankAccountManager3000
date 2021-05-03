using FluentValidation;

namespace BankAccountManager3000.Application.BankAccounts.Commands.AddBankAccount
{
    public class AddBankAccountValidator : AbstractValidator<AddBankAccountCommand>
    {
        public AddBankAccountValidator()
        {
            RuleFor(x => x.BankName).NotEmpty();

            RuleFor(x => x.Iban).NotEmpty();
            RuleFor(x => x.Iban).Must(x => x.StartsWith("FR"))
                .WithMessage("L'application n'accepte que les IBAN de comptes français");

            RuleFor(x => x.Bic).NotEmpty();
        }
    }
}