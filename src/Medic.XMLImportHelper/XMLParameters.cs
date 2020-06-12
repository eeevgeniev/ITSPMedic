using System;

namespace Medic.XMLImportHelper
{
    public class XMLParameters
    {
        public XMLParameters(string encoding, string xmlns)
        {
            Encoding = encoding;
            Xmlns = xmlns;
        }

        public string Encoding { get; }

        public string Xmlns { get; }
    }
}