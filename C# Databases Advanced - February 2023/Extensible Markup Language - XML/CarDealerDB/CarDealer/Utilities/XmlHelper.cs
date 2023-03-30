namespace CarDealer.Utilities;

using System.Text;
using System.Xml.Serialization;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader reader = new StringReader(inputXml);
        T deserializedDTOs = (T)xmlSerializer.Deserialize(reader)!;

        return deserializedDTOs;
    }

    public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(T[]), xmlRoot);

        using StringReader reader = new StringReader(inputXml);
        T[] deserializedDTOsArray =
            (T[])xmlSerializer.Deserialize(reader)!;

        return deserializedDTOsArray;
    }

    public string Serialize<T>(T obj, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        StringBuilder output = new StringBuilder();
        using StringWriter writer = new StringWriter(output);

        xmlSerializer.Serialize(writer, obj, xmlNamespaces);

        return output.ToString().TrimEnd();
    }

    public string Serialize<T>(T[] obj, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        StringBuilder output = new StringBuilder();
        using StringWriter writer = new StringWriter(output);

        xmlSerializer.Serialize(writer, obj, xmlNamespaces);

        return output.ToString().TrimEnd();
    }
}
