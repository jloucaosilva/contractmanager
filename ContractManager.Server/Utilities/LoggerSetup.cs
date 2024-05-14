using System;
using System.Collections;
using Destructurama;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace ContractManager.Server.Utilities;

/// <summary>
/// Extension methods for configuring the logger
/// </summary>
public class LoggerSetup
{
    /// <summary>
    /// Configures the logger for the application
    /// </summary>
    /// <returns>The setup <see cref="ILogger"/> instance</returns>
    public static ILogger BootstrapLogger()
    {
        var logger = new LoggerConfiguration();
            
            Setup(logger);

            return logger
                .CreateBootstrapLogger();
    }
    
    /// <summary>
    /// Configures the logger for the application
    /// </summary>
    /// <param name="context">The <see cref="HostBuilderContext"/> instance</param>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/> instance</param>
    /// <param name="loggerConfiguration">The <see cref="LoggerConfiguration"/> instance</param>
    public static void BuildHostLogger(HostBuilderContext context, IServiceProvider serviceProvider, LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
        
        Setup(loggerConfiguration);

        loggerConfiguration.ReadFrom.Services(serviceProvider);
    }

    /// <summary>
    /// Configures the logger for the consumption of teh logger setup extnsions
    /// </summary>
    /// <param name="loggerConfiguration">The <see cref="LoggerConfiguration"/> instance to be setup</param>
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