using Account.Users.GrpcService.Services;
using Core.Contracts.Grpc.Services.Account.Users;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCodeFirstGrpc(config =>
{
    config.EnableDetailedErrors = true;
});

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<UsersGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
