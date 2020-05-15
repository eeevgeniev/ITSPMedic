using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class DrugProtocol
    {
        [XmlElement(ElementName = "Type_Therapy")]
        public int TherapyType { get; set; }
        
        [XmlElement(ElementName = "ATC_Code")]
        public string ATCCode { get; set; }

        [XmlElement(ElementName = "ATC_Name")]
        public string ATCName { get; set; }

        [XmlElement(ElementName = "Days")]
        public string Days { get; set; }

        [XmlElement(ElementName = "Application_Way")]
        public string ApplicationWay { get; set; }

        [XmlElement(ElementName = "Standart_Dose")]
        public decimal StandartDose { get; set; }

        [XmlElement(ElementName = "Individual_Dose")]
        public decimal IndividualDose { get; set; }

        [XmlElement(ElementName = "Cycle_Dose")]
        public decimal CycleDose { get; set; }

        [XmlElement(ElementName = "All_Dose")]
        public decimal AllDose { get; set; }
    }
}
