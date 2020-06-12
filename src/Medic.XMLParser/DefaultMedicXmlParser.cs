using Medic.XMLImportHelper;
using Medic.XMLImportHelper.Contracts;
using Medic.XMLImportHelper.Enumerations;
using Medic.XMLParser.Contracts;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Medic.XMLParser
{
    public class DefaultMedicXmlParser : IMedicXmlParser
    {
        private readonly IGetXmlParameters GetXmlParameters;

        public DefaultMedicXmlParser(IGetXmlParameters getXmlParameters)
        {
            GetXmlParameters = getXmlParameters ?? throw new ArgumentNullException(nameof(getXmlParameters));
        }

        public T ParseXML<T>(Stream stream) where T : class
        {
            if (stream == default)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            XMLParameters xmlParameters = GetXmlParameters
                        .GetParameters(stream, FileTypeEnumeration.CpFile);

            Encoding encoding = string.IsNullOrEmpty(xmlParameters.Encoding) ? Encoding.UTF8 : Encoding.GetEncoding(xmlParameters.Encoding);
            XmlSerializer xmlSerializer = string.IsNullOrEmpty(xmlParameters.Xmlns) ?
                new XmlSerializer(typeof(T), string.Empty) :
                new XmlSerializer(typeof(T), xmlParameters.Xmlns);

            stream.Position = 0;

            using StreamReader streamReader = new StreamReader(stream, encoding);

            if (xmlSerializer.Deserialize(streamReader) is T result)
            {
                return result;
            }

            throw new InvalidOperationException();
        }
    }
}
