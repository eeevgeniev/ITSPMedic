using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class AccompanyingDrug
    {
        [XmlElement(ElementName = "Type_Therapy")]
        public int TherapyType { get; set; }

        [XmlElement(ElementName = "ATC_Code")]
        public string ATCCode { get; set; }

        [XmlElement(ElementName = "ATC_Name")]
        public string ATCName { get; set; }

        [XmlElement(ElementName = "Single_Dose")]
        public decimal SingleDose { get; set; }

        [XmlElement(ElementName = "All_Dose")]
        public decimal AllDose { get; set; }
    }
}