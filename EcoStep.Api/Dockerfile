# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EcoStep.Api/EcoStep.Api.csproj", "EcoStep.Api/"]
COPY ["EcoStep.Application/EcoStep.Application.csproj", "EcoStep.Application/"]
COPY ["EcoStep.Infraestructure/EcoStep.Infrastructure.csproj", "EcoStep.Infraestructure/"]
COPY ["EcoStep.Domain/EcoStep.Domain.csproj", "EcoStep.Domain/"]
COPY ["EcoStep.Shared/EcoStep.Shared.csproj", "EcoStep.Shared/"]
RUN dotnet restore "./EcoStep.Api/EcoStep.Api.csproj"
COPY . .
WORKDIR "/src/EcoStep.Api"
RUN dotnet build "./EcoStep.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EcoStep.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcoStep.Api.dll"]