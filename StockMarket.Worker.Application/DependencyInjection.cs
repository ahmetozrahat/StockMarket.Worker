using Microsoft.Extensions.DependencyInjection;
using StockMarket.Worker.Application.Common.Services.Abstract;
using StockMarket.Worker.Application.Common.Services.Concrete;

namespace StockMarket.Worker.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IStockScraper, StockScraper>();
        services.AddSingleton<IExchangeRateScraper, ExchangeRateScraper>();
    }
}