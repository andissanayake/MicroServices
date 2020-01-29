FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/AdminPortal/Admin.UI/Admin.UI.csproj src/AdminPortal/Admin.UI/
RUN dotnet restore src/AdminPortal/Admin.UI/Admin.UI.csproj
COPY . .
WORKDIR /src/src/AdminPortal/Admin.UI
RUN dotnet build Admin.UI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Admin.UI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Admin.UI.dll"]
