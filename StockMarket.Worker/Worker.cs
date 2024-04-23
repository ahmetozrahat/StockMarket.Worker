using StockMarket.Worker.Application.Common.Interfaces;
using StockMarket.Worker.Application.Common.Services.Abstract;

namespace StockMarket.Worker;

public class Worker(
    ILogger<Worker> logger,
    IHostApplicationLifetime lifetime,
    IStockScraper stockScraper,
    IStockRepository stockRepository,
    IExchangeRateRepository exchangeRateRepository,
    IExchangeRateScraper exchangeRateScraper
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var stocks = await stockScraper.GetStocksAsync();
        await stockRepository.UpdateStocksAsync(stocks);

        var exchangeRates = await exchangeRateScraper.GetExchangeRatesAsync();
        await exchangeRateRepository.UpdateExchangeRatesAsync(exchangeRates);

        lifetime.StopApplication();
    }
}