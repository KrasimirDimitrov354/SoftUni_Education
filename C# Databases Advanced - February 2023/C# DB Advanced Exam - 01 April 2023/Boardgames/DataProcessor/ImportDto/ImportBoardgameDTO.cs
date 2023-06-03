namespace Boardgames.DataProcessor.ImportDto;

using System.Xml.Serialization;

[XmlType("Boardgame")]
public class ImportBoardgameDTO
{
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [XmlElement("Rating")]
    public double Rating { get; set; }

    [XmlElement("YearPublished")]
    public int YearPublished { get; set; }

    [XmlElement("CategoryType")]
    public int CategoryType { get; set; }

    [XmlElement("Mechanics")]
    public string Mechanics { get; set; } = null!;
}
