namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ExportCreatorDTO
{
    [XmlAttribute("BoardgamesCount")]
    public string BoardgamesCount { get; set; } = null!;

    [XmlElement("CreatorName")]
    public string CreatorName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ExportBoardgameDTO[] Boardgames { get; set; } = null!;
}
