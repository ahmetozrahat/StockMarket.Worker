using System.Data;
using Dapper;
using StockMarket.Worker.Application.Common.Interfaces;
using StockMarket.Worker.Core.DataAccess.Abstract;
using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Infrastructure.Repositories;

public class ExchangeRateRepository(IDbContext context) : IExchangeRateRepository
{
    public async Task UpdateExchangeRatesAsync(IEnumerable<ExchangeRate> exchangeRates)
    {
        using var con = context.CreateConnection();
        try
        {
            foreach (var exchangeRate in exchangeRates)
            {
                await con.ExecuteAsync("SP_UpdateExchangeRateCommand", exchangeRate, commandType: CommandType.StoredProcedure);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}