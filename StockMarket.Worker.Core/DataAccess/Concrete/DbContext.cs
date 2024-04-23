using System.Data;
using System.Data.SqlClient;
using StockMarket.Worker.Core.DataAccess.Abstract;

namespace StockMarket.Worker.Core.DataAccess.Concrete;

public class DbContext : IDbContext
{
    public IDbConnection CreateConnection()
    {
        var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        return new SqlConnection(connectionString);
    }
}