FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FlightManager.DataInitialization/FlightManager.DataInitialization.csproj", "FlightManager.DataInitialization/"]
RUN dotnet restore "FlightManager.DataInitialization/FlightManager.DataInitialization.csproj"
COPY . .
WORKDIR "/src/FlightManager.DataInitialization"
RUN dotnet build "FlightManager.DataInitialization.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlightManager.DataInitialization.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlightManager.DataInitialization.dll"]
