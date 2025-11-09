# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Account.Users.WebApi/Account.Users.WebApi.csproj", "src/Account.Users.WebApi/"]
COPY ["libraries/Core.Implementation.ServicesAssembly/Core.Implementation.ServicesAssembly.csproj", "libraries/Core.Implementation.ServicesAssembly/"]
COPY ["libraries/Core.Implementation.ApiExplorer/Core.Implementation.ApiExplorer.csproj", "libraries/Core.Implementation.ApiExplorer/"]
COPY ["libraries/Core.Implementation.Logging/Core.Implementation.Logging.csproj", "libraries/Core.Implementation.Logging/"]
COPY ["libraries/Core.Implementation.Telemetry/Core.Implementation.Telemetry.csproj", "libraries/Core.Implementation.Telemetry/"]
COPY ["src/Account.Users.Infrastructure/Account.Users.Infrastructure.csproj", "src/Account.Users.Infrastructure/"]
COPY ["src/Account.Users.Application/Account.Users.Application.csproj", "src/Account.Users.Application/"]
COPY ["src/Account.Users.Domain/Account.Users.Domain.csproj", "src/Account.Users.Domain/"]
COPY ["libraries/Core.Abstraction/Core.Abstraction.csproj", "libraries/Core.Abstraction/"]
RUN dotnet restore "./src/Account.Users.WebApi/Account.Users.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Account.Users.WebApi"
RUN dotnet build "./Account.Users.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Account.Users.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Account.Users.WebApi.dll"]