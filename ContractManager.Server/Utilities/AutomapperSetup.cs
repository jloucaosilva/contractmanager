using Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ContractManager.Server.Utilities;

/// <summary>
/// Extension methods for configuring Automapper
/// </summary>
public static class AutomapperSetup
{
    /// <summary>
    /// Configures Automapper for application using
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance we are extending</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(typeof(MappingsAssemblyIdentifier));
    }
}