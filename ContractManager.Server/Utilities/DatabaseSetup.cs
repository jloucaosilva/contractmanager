using DataAccessLayer.Context;
using DataAccessLayer.Context.Implementation;
using DataAccessLayer.Context.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ContractManager.Server.Utilities;

/// <summary>
/// Extension methods for configuring the database
/// </summary>
public static class DatabaseSetup
{
    /// <summary>
    /// Configures the database for the application
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance we are extending</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
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