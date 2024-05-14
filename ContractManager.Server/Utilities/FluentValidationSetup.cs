using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PublicContracts;
using PublicContracts.Requests.Validators;

namespace ContractManager.Server.Utilities;

public static class FluentValidationSetup
{
    public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
    {
        return services.AddFluentValidationAutoValidation(fv =>
        {
            fv.DisableDataAnnotationsValidation = true;
        }).AddValidatorsFromAssemblyContaining<PublicContractsAssemblyIdentifier>();
    }
}