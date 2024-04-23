using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Application.Common.Services.Abstract;

public interface IStockScraper
{
    Task<IEnumerable<Stock>> GetStocksAsync();
}