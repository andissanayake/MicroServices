FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Analytics/HealthCheck/HealthCheck.csproj src/Analytics/HealthCheck/
RUN dotnet restore src/Analytics/HealthCheck/HealthCheck.csproj
COPY . .
WORKDIR /src/src/Analytics/HealthCheck
RUN dotnet build HealthCheck.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HealthCheck.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HealthCheck.dll"]
