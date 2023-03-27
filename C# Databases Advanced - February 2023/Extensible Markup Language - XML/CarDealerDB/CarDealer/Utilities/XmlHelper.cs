namespace CarDealer.Utilities;

using System.Xml.Serialization;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        var xmlRoot = new XmlRootAttribute(rootName);
        var xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader reader = new StringReader(inputXml);
        T deserializedDTOs = (T)xmlSerializer.Deserialize(reader)!;

        return deserializedDTOs;
    }
}
