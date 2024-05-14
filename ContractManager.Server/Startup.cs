using ContractManager.Server.Utilities;
using DataAccessLayer.Repositories.Implementation;
using DataAccessLayer.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublicContracts.Requests.Validators;
using Serilog;
using Serilog.Extensions.Logging;

namespace ContractManager.Server;

public class Startup
{
    private IConfiguration Configuration { get; }

    private readonly IWebHostEnvironment _environment;

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class.
    /// Startup class is called by the ASP.NET Core runtime. The runtime uses the Startup class to specify the startup configuration for the application.
    /// </summary>
    /// <param name="configuration">Represents a set of key/value application configuration properties</param>
    /// <param name="environment">Hosting environment </param>
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        _environment = environment;
    }
    
    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services">The service collection to extend and register DI</param>
    public void ConfigureServices(IServiceCollection services)
    {
        using (var loggerFactory = new SerilogLoggerFactory(Log.Logger))
        {
            services.AddSingleton(loggerFactory);
            
            // In-memory database is being used regardless of its restrictions as this is a demo project
            services.ConfigureDatabase();            
            
            services.AddControllers();
            
            services.ConfigureFluentValidation();
            
            services.ConfigureAutomapper();
                
            services.Configure<KestrelServerOptions>(opts =>
            {
                opts.Limits.MaxRequestBodySize = 10 * 1024 * 1024; // 10MB
            });

            services.AddHttpClient();
            services.AddHttpContextAccessor();
        
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.AddScoped<ILegalContractRepository, LegalContractRepository>();
        }
    }
    
    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">The application instance to be used to configure the application</param>
    public void Configure(IApplicationBuilder app)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (_environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("/index.html");
        });
    }
}