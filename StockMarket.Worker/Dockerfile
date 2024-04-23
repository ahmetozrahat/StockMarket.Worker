FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StockMarket.Worker/StockMarket.Worker.csproj", "StockMarket.Worker/"]
RUN dotnet restore "StockMarket.Worker/StockMarket.Worker.csproj"
COPY . .
WORKDIR "/src/StockMarket.Worker"
RUN dotnet build "StockMarket.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StockMarket.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockMarket.Worker.dll"]
