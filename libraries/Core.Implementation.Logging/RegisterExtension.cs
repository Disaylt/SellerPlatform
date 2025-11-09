using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Core.Implementation.Logging;

public static class RegisterExtension
{
    public static void AddCoreLogging(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithProperty("ServiceName", context.HostingEnvironment.ApplicationName)
            .WriteTo.Console(formatter: new Serilog.Formatting.Json.JsonFormatter())
            .WriteTo.File(
                new Serilog.Formatting.Json.JsonFormatter(),
                "/app/logs/webapi.log",
                rollingInterval: RollingInterval.Day
            )
        );
    }

    public static void UseCoreRequestLogging(this WebApplication host)
    {
        host.UseSerilogRequestLogging();
    }
}