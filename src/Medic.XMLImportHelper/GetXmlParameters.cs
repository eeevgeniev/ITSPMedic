using Medic.XMLImportHelper.Contracts;
using Medic.XMLImportHelper.Enumerations;
using System;
using System.IO;
using System.Xml;

namespace Medic.XMLImportHelper
{
    public class GetXmlParameters : IGetXmlParameters
    {
        public XMLParameters GetParameters(string filePath, FileTypeEnumeration fileType)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            using Stream reader = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return GetParameters(reader, fileType);
        }

        public XMLParameters GetParameters(Stream stream, FileTypeEnumeration fileType)
        {
            if (stream == default)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            
            using XmlReader xmlReader = XmlReader.Create(stream);

            const string encoding = "encoding";
            const string xmlns = "xmlns";

            string encodingResult = string.Empty;
            string xmlnsResult = string.Empty;

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.XmlDeclaration)
                {
                    if (xmlReader.HasAttributes)
                    {
                        while (xmlReader.MoveToNextAttribute())
                        {
                            if (string.Equals(xmlReader.Name, encoding, StringComparison.OrdinalIgnoreCase))
                            {
                                encodingResult = xmlReader.Value;
                            }
                        }
                    }
                }

                if (xmlReader.NodeType == XmlNodeType.Element && string.Equals(xmlReader.Name, fileType.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        if (string.Equals(xmlReader.Name, xmlns, StringComparison.OrdinalIgnoreCase))
                        {
                            xmlnsResult = xmlReader.Value;
                        }
                    }

                    break;
                }
            }

            return new XMLParameters(encodingResult, xmlnsResult);
        }
    }
}
