using Account.Notifications.Infrastructure.Models.Common;
using Account.Notifications.Application;
using Account.Notifications.Infrastructure;
using Core.Implementation.ServicesAssembly;
using Account.Notifications.WebApi;
using Scalar.AspNetCore;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Account.Notifications.WebApi.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<NotificationsInfrastructureOptions>(builder.Configuration);

var infrastructureOptions = builder.Configuration
    .Get<NotificationsInfrastructureOptions>()
    ?? throw new NullReferenceException(nameof(NotificationsInfrastructureOptions));

builder.AddCoreDefaultServices();

builder.Services
    .AddOpenApi("v1")
    .AddOpenApi("v2")
    .AddProblemDetails()
    .AddExceptionHandler<CoreRequestExceptionHandler>()
    .AddEndpointsApiExplorer()
    .AddAppVersioning()
    .AddApplicationsServices()
    .AddInfrastructureServices(infrastructureOptions);

builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandler();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseCoreDefault();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
