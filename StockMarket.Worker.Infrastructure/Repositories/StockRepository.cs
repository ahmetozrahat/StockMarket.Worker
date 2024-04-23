using System.Data;
using Dapper;
using StockMarket.Worker.Application.Common.Interfaces;
using StockMarket.Worker.Core.DataAccess.Abstract;
using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Infrastructure.Repositories;

public class StockRepository(IDbContext context) : IStockRepository
{
    public async Task UpdateStocksAsync(IEnumerable<Stock> stocks)
    {
        using var con = context.CreateConnection();
        try
        {
            foreach (var stock in stocks)
            {
                await con.ExecuteAsync("SP_UpdateStockCommand", stock, commandType: CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}