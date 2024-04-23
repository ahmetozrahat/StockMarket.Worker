using System.Data;

namespace StockMarket.Worker.Core.DataAccess.Abstract;

public interface IDbContext
{
    IDbConnection CreateConnection();
}