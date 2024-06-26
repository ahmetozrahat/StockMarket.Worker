using StockMarket.Worker.Application.Common.Services.Abstract;
using StockMarket.Worker.Core.Transformation.Common.Serializers;
using StockMarket.Worker.Domain.Entity;

namespace StockMarket.Worker.Application.Common.Services.Concrete;

public class ExchangeRateScraper : IExchangeRateScraper
{
    public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync()
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(Environment.GetEnvironmentVariable("EXCHANGE_RATE_API_URL"));
        if (!response.IsSuccessStatusCode) return new List<ExchangeRate>();
        var xmlContent = await response.Content.ReadAsStringAsync();
        var serializer = new CurrencyListSerializer();
        var currencyList = await serializer.DeserializeAsync(xmlContent);
        return currencyList.Currency.Select(x => new ExchangeRate()
        {
            Code = x.Kod,
            Name = x.Isim,
            Unit = x.Unit,
            BuyingPrice = string.IsNullOrEmpty(x.ForexBuying) ? 0 : Convert.ToDecimal(x.ForexBuying),
            SellingPrice = string.IsNullOrEmpty(x.ForexSelling) ? 0 : Convert.ToDecimal(x.ForexSelling),
            UpdatedAt = DateTime.Now,
        }).ToList();
    }
}