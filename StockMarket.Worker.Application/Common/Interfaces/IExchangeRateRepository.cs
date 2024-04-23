using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Application.Common.Interfaces;

public interface IExchangeRateRepository
{
    Task UpdateExchangeRatesAsync(IEnumerable<ExchangeRate> exchangeRates);
}