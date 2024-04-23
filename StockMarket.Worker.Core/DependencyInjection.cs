using Microsoft.Extensions.DependencyInjection;
using StockMarket.Worker.Core.DataAccess.Abstract;
using StockMarket.Worker.Core.DataAccess.Concrete;

namespace StockMarket.Worker.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddDapperORM(this IServiceCollection services)
    {
        services.AddSingleton<IDbContext, DbContext>();
        return services;
    }
}