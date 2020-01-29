FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/OpenID/Auth.UI/Auth.UI.csproj src/OpenID/Auth.UI/
RUN dotnet restore src/OpenID/Auth.UI/Auth.UI.csproj
COPY . .
WORKDIR /src/src/OpenID/Auth.UI
RUN dotnet build Auth.UI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Auth.UI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Auth.UI.dll"]
