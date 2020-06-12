using Medic.XMLImportHelper.Enumerations;
using System.IO;

namespace Medic.XMLImportHelper.Contracts
{
    public interface IGetXmlParameters
    {
        XMLParameters GetParameters(string filePath, FileTypeEnumeration fileType);

        XMLParameters GetParameters(Stream stream, FileTypeEnumeration fileType);
    }
}
