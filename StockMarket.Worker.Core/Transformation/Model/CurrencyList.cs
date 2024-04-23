using System.Xml.Serialization;

namespace StockMarket.Worker.Core.Transformation.Model;

[XmlRoot(ElementName="Tarih_Date")]
public class CurrencyList { 

    [XmlElement(ElementName="Currency")] 
    public List<Currency> Currency { get; set; } 

    [XmlAttribute(AttributeName="Tarih")] 
    public string Tarih { get; set; } 

    [XmlAttribute(AttributeName="Date")] 
    public string Date { get; set; } 

    [XmlAttribute(AttributeName="Bulten_No")] 
    public string BultenNo { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}