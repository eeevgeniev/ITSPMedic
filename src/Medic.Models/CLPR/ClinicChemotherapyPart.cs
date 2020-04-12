using Medic.Models.CP;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.Models.CLPR
{
    public class ClinicChemotherapyPart
    {
        public int ECOG { get; set; }

        public string TNM { get; set; }

        public Evaluation Evaluation { get; set; }

        [XmlElement(ElementName = "Decision")]
        public List<Evaluation> Decisions { get; set; }
    }
}
