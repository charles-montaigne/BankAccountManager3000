using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankAccountManager3000.Application.Common.Interfaces;
using BankAccountManager3000.Domain.Entities;
using MediatR;

namespace BankAccountManager3000.Application.BankAccounts.Commands.AddBankAccount
{
    public class AddBankAccountHandler : IRequestHandler<AddBankAccountCommand, AddBankAccountResponse>
    {
        private readonly IBankAccountContext context;

        public AddBankAccountHandler(IBankAccountContext context)
        {
            this.context = context;
        }

        public async Task<AddBankAccountResponse> Handle(AddBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = new BankAccount
            {
                BankName = request.BankName,
                Bic = request.Bic,
                CreationDate = DateTime.Now,
                HolderName = request.HolderName,
                Iban = request.Iban
            };

            context.BankAccounts.Add(bankAccount);

            await context.SaveChangesAsync(cancellationToken);

            var response = new AddBankAccountResponse
            {
                BankAccountId = bankAccount.Id
            };

            return response;
        }
    }
}
