using BankAccountManager3000.Application.BankAccounts.Commands.AddBankAccount;
using BankAccountManager3000.Application.Common.Interfaces;
using BankAccountManager3000.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountManager3000.Api.Controllers
{
    public class BankAccountController : ApiControllerBase
    {
        private readonly IBankAccountContext context;

        public BankAccountController(IBankAccountContext context)
        {
            this.context = context;
        }

        [HttpPost("add-bank-account")]
        public async Task<ActionResult<AddBankAccountResponse>> AddBankAccount(AddBankAccountCommand command)
        {
            var response = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetBankAccount), new { id = response.BankAccountId }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            var response = await context.BankAccounts.FindAsync(id);

            if (response is null)
                return NotFound();
            else
                return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<BankAccount>> GetBankAccounts()
        {
            var response = await context.BankAccounts.ToListAsync();

            if (response is null)
                return NotFound();
            else
                return Ok(response);
        }

        [HttpDelete("reset-database")]
        public async Task<ActionResult> ResetDatabase()
        {
            context.BankAccounts.RemoveRange(context.BankAccounts);
            await context.SaveChangesAsync(new System.Threading.CancellationToken());
            return Ok();
        }
    }
}
