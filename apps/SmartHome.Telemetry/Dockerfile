FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartHome.Telemetry/SmartHome.Telemetry.csproj", "SmartHome.Telemetry/"]
RUN dotnet restore "./SmartHome.Telemetry/SmartHome.Telemetry.csproj"
COPY . .
WORKDIR "/src/SmartHome.Telemetry"
RUN dotnet build "./SmartHome.Telemetry.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartHome.Telemetry.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartHome.Telemetry.dll"]