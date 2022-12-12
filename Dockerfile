FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# Copy everything
COPY ["./Microservicios/Microservicios.csproj", "Microservicios/"]
COPY ["./Microservicios_dal/Microservicios_dal.csproj", "Microservicios_dal/"]
COPY ["./Microservicios_common/Microservicios_common.csproj", "Microservicios_common/"]
COPY ["./Microservicios_bl/Microservicios_bl.csproj", "Microservicios_bl/"]

# Restore as distinct layers
RUN dotnet restore "Microservicios/Microservicios.csproj"

COPY ./. .
WORKDIR "/src/Microservicios"
# Build and publish a release
RUN dotnet build "Microservicios.csproj" -o /app/build
RUN dotnet publish "Microservicios.csproj" -o /app/publish
WORKDIR "/src/Microservicios"


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Microservicios.dll"]