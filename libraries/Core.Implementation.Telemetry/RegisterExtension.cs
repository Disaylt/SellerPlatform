using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

namespace Core.Implementation.Telemetry;

public static class RegisterExtension
{
    public static void AddCoreTelemetry(this IHostApplicationBuilder hostApplicationBuilder)
    {
        string applicationName = hostApplicationBuilder.Environment.ApplicationName;

        hostApplicationBuilder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics
                    .SetResourceBuilder(ResourceBuilder
                        .CreateDefault()
                        .AddService(applicationName))
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation()
                    .AddPrometheusExporter();
            });
    }

    public static void UseCoreTelemetry(this WebApplication webApplication)
    {
        webApplication.UseOpenTelemetryPrometheusScrapingEndpoint();
    }
}