using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Application.Common.Interfaces;

public interface IStockRepository
{
    Task UpdateStocksAsync(IEnumerable<Stock> stocks);
}