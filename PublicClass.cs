using System.Xml.Serialization;

namespace XMLSerializerGeneratorTests
{
    [XmlRoot(Namespace = "http://itml.sbc.de/layout/2011/1")]
    public class PublicClass
    {
        private class PrivateClass
        {
        }
    }
}
