using Medic.Models.CP;
using Medic.XMLImportHelper;
using Medic.XMLParser;
using System;
using System.IO;
using Xunit;

namespace Medic.Tests.XmlParser
{
    public class TestDefaultMedicXmlParser
    {
        [Fact]
        public void DefaultMedicXmlParser_Throws_ArgumentNullException_If_IGetXmlParameters_Is_Default()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                DefaultMedicXmlParser defaultMedicXmlParser = new DefaultMedicXmlParser(default);
            });
        }

        [Fact]
        public void DefaultMedicXmlParser_Throws_ArgumentNullException_If_Stream_Is_Default()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                GetXmlParameters parameters = new GetXmlParameters();

                DefaultMedicXmlParser defaultMedicXmlParser = new DefaultMedicXmlParser(parameters);

                defaultMedicXmlParser.ParseXML<CPFile>(default);
            });
        }

        [Fact]
        public void DefaultMedicXmlParser_Throws_InvalidOperationException_If_Wrong_File_Is_Passed()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                GetXmlParameters parameters = new GetXmlParameters();

                DefaultMedicXmlParser defaultMedicXmlParser = new DefaultMedicXmlParser(parameters);

                using FileStream stream = new FileStream(Path.Combine(@".\Files\clpr.xml"), FileMode.Open, FileAccess.Read);

                defaultMedicXmlParser.ParseXML<CPFile>(stream);
            });
        }

        [Fact]
        public void DefaultMedicXmlParser_Parses_Correctly()
        {
            GetXmlParameters parameters = new GetXmlParameters();

            DefaultMedicXmlParser defaultMedicXmlParser = new DefaultMedicXmlParser(parameters);

            using FileStream stream = new FileStream(Path.Combine(@".\Files\cp.xml"), FileMode.Open, FileAccess.Read);

            Assert.IsType<CPFile>(defaultMedicXmlParser.ParseXML<CPFile>(stream));
        }
    }
}
