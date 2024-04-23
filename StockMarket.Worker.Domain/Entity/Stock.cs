using StockMarket.Worker.Domain.Enum;

namespace StockMarket.Worker.Domain.Entity;

public class Stock
{
    public string Code { get; set; }
    public decimal Price { get; set; }
    public double ChangePercentage { get; set; }
    public ChangeType ChangeType { get; set; }
    public DateTime UpdatedAt { get; set; }
}