using Core.Implementation.Logging;
using Core.Implementation.Telemetry;
using Microsoft.AspNetCore.Builder;

namespace Core.Implementation.ServicesAssembly;

public static class RegisterExtension
{
    public static void AddCoreDefaultServices(this WebApplicationBuilder builder)
    {
        builder.Host.AddCoreLogging();
        builder.AddCoreTelemetry();
    }

    public static void UseCoreDefault(this WebApplication webApplication)
    {
        webApplication.UseCoreRequestLogging();
        webApplication.UseCoreTelemetry();
    }
}