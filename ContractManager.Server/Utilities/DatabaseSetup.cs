using DataAccessLayer.Context;
using DataAccessLayer.Context.Implementation;
using DataAccessLayer.Context.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ContractManager.Server.Utilities;

public static class DatabaseSetup
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ContractManagerDbContext>(opts =>
        {
                
            opts.EnableDetailedErrors();
        }, optionsLifetime: ServiceLifetime.Singleton);
        services.AddSingleton<IContractManagerContextFactory, ContractManagerContextFactory>();

        return services;
    }
}