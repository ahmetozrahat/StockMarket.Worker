using Microsoft.Extensions.DependencyInjection;
using StockMarket.Worker.Application;
using StockMarket.Worker.Application.Common.Interfaces;
using StockMarket.Worker.Core;
using StockMarket.Worker.Infrastructure.Repositories;

namespace StockMarket.Worker.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDapperORM();

        services.AddSingleton<IStockRepository, StockRepository>();
        services.AddSingleton<IExchangeRateRepository, ExchangeRateRepository>();

        services.AddApplicationServices();
    }
}