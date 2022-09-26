using Credit.ApplicationCore.DTOs.AppSettings;
using Credit.ApplicationCore.Interfaces;
using Credit.ApplicationCore.Services;
using Credit.Infrastructure.Data;
using Credit.Infrastructure.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Credit.Api.Configurations
{
    public class DependencyInjectionConfiguration : IDependencyInjectionConfiguration
    {
        public virtual void AddLogger(IServiceCollection services)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            services.AddSingleton<Serilog.ILogger>(x => logger);
        }

        public virtual AppSettings AddAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            var appSettings = new AppSettings();
            new ConfigureFromConfigurationOptions<AppSettings>(configuration.GetSection("AppSettings")).Configure(appSettings);

            return appSettings;
        }

        public virtual void AddApplicationCore(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }

        public virtual void AddDatabase(IServiceCollection services) =>
            services.AddScoped<IEFContext, EFContext>();

        public virtual void AddInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}