FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY Microservicios_common/* ./
COPY Microservicios_common/Microservicios_dal/* ./

RUN dotnet restore

WORKDIR /app/
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM base AS final
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Microservicios_bl.dll"]