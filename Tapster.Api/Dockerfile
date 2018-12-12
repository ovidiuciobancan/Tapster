FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Tapster.Api/Tapster.Api.csproj Tapster.Api/
RUN dotnet restore Tapster.Api/Tapster.Api.csproj
COPY . .
WORKDIR /src/Tapster.Api
RUN dotnet build Tapster.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Tapster.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tapster.Api.dll"]
