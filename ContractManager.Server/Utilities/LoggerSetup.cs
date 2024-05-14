using System;
using System.Collections;
using Destructurama;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace ContractManager.Server.Utilities;

public class LoggerSetup
{
    public static ILogger BootstrapLogger()
    {
        var logger = new LoggerConfiguration();
            
            Setup(logger);

            return logger
                .CreateBootstrapLogger();
    }
    
    public static void BuildHostLogger(HostBuilderContext context, IServiceProvider serviceProvider,LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
        
        Setup(loggerConfiguration);

        loggerConfiguration.ReadFrom.Services(serviceProvider);
    }

    private static void Setup(LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            .Destructure.ToMaximumDepth(25)
            .Destructure.ToMaximumStringLength(1000)
            .Destructure.ToMaximumCollectionCount(1000)
            .Destructure.AsScalar<Enum>()
            .Destructure.AsScalar<IEnumerable>()
            .Destructure.AsScalar(typeof(IEnumerable))
            .Destructure.UsingAttributes()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console(theme: AnsiConsoleTheme.Literate);
    }
}