using System.Xml.Serialization;

namespace XMLSerializerGeneratorTests;

internal class Executor
{
    private void Execute()
    {
        var serializer = new XmlSerializer(typeof(PublicPassedToXmlSerializerClass));
    }
}