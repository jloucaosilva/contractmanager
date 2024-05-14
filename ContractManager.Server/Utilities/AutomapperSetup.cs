using Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ContractManager.Server.Utilities;

public static class AutomapperSetup
{
    public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(typeof(MappingsAssemblyIdentifier));
    }
}