using Core.Implementation.ServicesAssembly;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.AddCoreDefaultServices();

var app = builder.Build();

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseCoreDefault();

app.Run();