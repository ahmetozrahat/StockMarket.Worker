using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Application.Common.Services.Abstract;

public interface IExchangeRateScraper
{
    Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync();
}