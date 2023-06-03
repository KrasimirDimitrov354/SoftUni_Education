namespace Boardgames.DataProcessor.ImportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ImportCreatorDTO
{
    [XmlElement("FirstName")]
    public string FirstName { get; set; } = null!;

    [XmlElement("LastName")]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgameDTO[] Boardgames { get; set; } = null!;
}
