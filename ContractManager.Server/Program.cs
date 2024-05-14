
using System;
using ContractManager.Server.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ContractManager.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = LoggerSetup.BootstrapLogger();

            try
            {
                var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, e.Message);
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(
                    (_, services) =>
                    {
                        services.Configure<HostOptions>(options =>
                        {
                            options.ShutdownTimeout = TimeSpan.FromSeconds(20);
                        });
                    })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
#if DEBUG
                        .CaptureStartupErrors(true);
#else
                        .CaptureStartupErrors(false);
#endif
                })
                .UseSerilog(LoggerSetup.BuildHostLogger, true);
        }
    }
}
