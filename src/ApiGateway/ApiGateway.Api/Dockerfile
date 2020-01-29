FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/ApiGateway/ApiGateway.Api/ApiGateway.Api.csproj src/ApiGateway/ApiGateway.Api/
RUN dotnet restore src/ApiGateway/ApiGateway.Api/ApiGateway.Api.csproj
COPY . .
WORKDIR /src/src/ApiGateway/ApiGateway.Api
RUN dotnet build ApiGateway.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ApiGateway.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiGateway.Api.dll"]
