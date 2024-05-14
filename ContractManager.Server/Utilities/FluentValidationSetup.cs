using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PublicContracts;

namespace ContractManager.Server.Utilities;

/// <summary>
/// Extension methods for configuring FluentValidation
/// </summary>
public static class FluentValidationSetup
{
    /// <summary>
    /// Configures FluentValidation for the application
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance we are extending</param>
    /// <returns>The <see cref="IServiceCollection"/></returns>
    public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
    {
        return services.AddFluentValidationAutoValidation(fv =>
        {
            fv.DisableDataAnnotationsValidation = true;
        }).AddValidatorsFromAssemblyContaining<PublicContractsAssemblyIdentifier>();
    }
}