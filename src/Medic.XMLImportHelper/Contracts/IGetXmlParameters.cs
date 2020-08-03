using Medic.XMLImportHelper.Enumerations;
using System.IO;

namespace Medic.XMLImportHelper.Contracts
{
    public interface IGetXmlParameters
    {
        XMLParameters GetParameters(string filePath, FileTypeEnums fileType);

        XMLParameters GetParameters(Stream stream, FileTypeEnums fileType);
    }
}
