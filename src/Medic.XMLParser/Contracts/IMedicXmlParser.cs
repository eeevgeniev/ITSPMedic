using System.IO;

namespace Medic.XMLParser.Contracts
{
    public interface IMedicXmlParser
    {
        T ParseXML<T>(Stream stream) where T : class;
    }
}
