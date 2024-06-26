using System.Globalization;
using StockMarket.Worker.Application.Common.Services.Abstract;
using StockMarket.Worker.Domain.Entity;
using HtmlAgilityPack;
using StockMarket.Worker.Domain.Enum;

namespace StockMarket.Worker.Application.Common.Services.Concrete;

public class StockScraper() : IStockScraper
{
    public async Task<IEnumerable<Stock>> GetStocksAsync()
    {
        List<Stock> stocks = [];
        var cultureInfo = new CultureInfo("tr-TR");
        
        #region HTML verisi alınır
        HttpClient client = new();
        var apiUrl = Environment.GetEnvironmentVariable("API_URL") ?? "";
        var html = await client.GetStringAsync(apiUrl);
        #endregion

        #region Tablo verileri alınır
        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);
        var nodes = htmlDocument.DocumentNode
            .Descendants("tr")
            .Where(node => node.GetAttributeValue("class","").Contains("zebra"))
            .ToList();
        #endregion

        #region Veriler modele dönüştürülür
        foreach (var node in nodes)
        {
            var stockName = node.Id.ToString().Split("h_tr_id_").Last();
            var stockPrice = node
                .Descendants("td")
                .Where(x => x.GetAttributeValue("id", "").Contains("h_td_fiyat"))
                .ToList().First().InnerText;
            var stockPercentage = node
                .Descendants("td")
                .Where(x => x.GetAttributeValue("id", "").Contains("h_td_yuzde"))
                .ToList().First().InnerText;
            var date = node
                .Descendants("td")
                .Where(x => x.GetAttributeValue("id", "").Contains("h_td_zaman"))
                .ToList().First().InnerText;

            decimal.TryParse(stockPrice, NumberStyles.Currency, cultureInfo, out var price);
            double.TryParse(stockPercentage, NumberStyles.Any, cultureInfo, out var percentage);
            Stock stock = new()
            {
                Code = stockName,
                Price = price,
                ChangePercentage = percentage,
                ChangeType = percentage > 0 ? ChangeType.INCREASE : ChangeType.DECREASE,
                UpdatedAt = Convert.ToDateTime(date)
            };
            stocks.Add(stock);
        }
        #endregion

        return stocks;
    }
}