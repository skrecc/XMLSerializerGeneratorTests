using System.Runtime.Loader;
using System.Xml.Serialization;

namespace XMLSerializerGeneratorTests;

public static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        AssemblyLoadContext.Default.Resolving += (ctx, name) =>
        {
            Console.WriteLine($"Resolving: {name}");
            return null;
        };

        AppDomain.CurrentDomain.AssemblyLoad += (_, e) =>
        {
            Console.WriteLine($"Loaded: {e.LoadedAssembly.FullName}");
        };

        var serializedTypeName = typeof(XmlRootAttributedClass);
        var serializer = new XmlSerializer(serializedTypeName);

        var serializerType = serializer.GetType();
        var implAsm = serializerType.Assembly;
        Console.WriteLine($"SGEN Serializer implementation assembly: {implAsm.GetName().Name} loaded for serialized type name: {serializedTypeName}. Serializer type name: {serializerType.FullName}");
        Console.WriteLine($"SGEN Location: '{implAsm.Location}'  IsDynamic: {implAsm.IsDynamic}");

        bool usedPreGenerated = implAsm.GetName().Name != null
                                && implAsm.GetName().Name.EndsWith("XmlSerializers")
                                && !string.IsNullOrEmpty(implAsm.Location);

        Console.WriteLine(usedPreGenerated
            ? "SGEN Using pre-generated serializer implementation."
            : "SGEN Using runtime-generated (reflection) serializer implementation.");

        Console.ReadLine();
    }
}