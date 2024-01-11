FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyVideoGames.WebUI/MyVideoGames.WebUI.csproj", "MyVideoGames.WebUI/"]
COPY ["MyVideoGames.Console.DataProvider/MyVideoGames.Console.DataProvider.csproj", "MyVideoGames.Console.DataProvider/"]
COPY ["MyVideoGames.DataContext/MyVideoGames.DataContext.csproj", "MyVideoGames.DataContext/"]
COPY ["MyVideoGames.Model/MyVideoGames.Model.csproj", "MyVideoGames.Model/"]
RUN dotnet restore "MyVideoGames.WebUI/MyVideoGames.WebUI.csproj"
COPY . .
WORKDIR "/src/MyVideoGames.WebUI"
RUN dotnet build "MyVideoGames.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyVideoGames.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyVideoGames.WebUI.dll"]
