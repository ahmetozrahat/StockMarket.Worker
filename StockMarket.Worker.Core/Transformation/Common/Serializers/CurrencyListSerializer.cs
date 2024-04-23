using System.Xml.Serialization;
using StockMarket.Worker.Core.Transformation.Model;

namespace StockMarket.Worker.Core.Transformation.Common.Serializers;

public class CurrencyListSerializer
{
    public async Task<CurrencyList> DeserializeAsync(string xmlDocument)
    {
        var serializer = new XmlSerializer(typeof(CurrencyList));
        using var stringReader = new StringReader(xmlDocument);
        return await Task.FromResult((CurrencyList)serializer.Deserialize(stringReader)!);
    }
}