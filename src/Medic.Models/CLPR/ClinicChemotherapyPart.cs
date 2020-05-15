using Medic.Models.CP;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class ClinicChemotherapyPart
    {
        [XmlElement(ElementName = "ECOG")]
        public int ECOG { get; set; }

        [XmlElement(ElementName = "TNM")]
        public string TNM { get; set; }

        [XmlElement(ElementName = "Evaluation")]
        public Evaluation Evaluation { get; set; }

        [XmlElement(ElementName = "Decision")]
        public List<Evaluation> Decisions { get; set; }
    }
}
