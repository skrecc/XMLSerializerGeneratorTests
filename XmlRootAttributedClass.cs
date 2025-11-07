using System.Xml.Serialization;

namespace XMLSerializerGeneratorTests;

[XmlRoot]
public class XmlRootAttributedClass
{
    public XmlRootAttributedClass()
    {
    }

    public string? XmlContent { get; set; }
}