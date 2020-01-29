FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Services/UserManager/UserManger.Api/UserManager.Api.csproj src/Services/UserManager/UserManger.Api/
RUN dotnet restore src/Services/UserManager/UserManger.Api/UserManager.Api.csproj
COPY . .
WORKDIR /src/src/Services/UserManager/UserManger.Api
RUN dotnet build UserManager.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish UserManager.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserManager.Api.dll"]
