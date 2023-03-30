namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("customer")]
public class ExportCustomerTotalSalesDTO
{
    [XmlAttribute("full-name")]
    public string Name { get; set; } = null!;

    [XmlAttribute("bought-cars")]
    public string CarsBought { get; set; } = null!;

    [XmlAttribute("spent-money")]
    public string MoneySpent { get; set; } = null!;
}
