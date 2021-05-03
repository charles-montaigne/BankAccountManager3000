using BankAccountManager3000.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccountManager3000.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBankAccountContext, BankAccountContext>();

            return services;
        }
    }
}