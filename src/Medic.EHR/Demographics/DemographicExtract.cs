using Medic.EHR.Complexes;
using Medic.EHR.Primitives;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicExtract<T> : DemographicFolder<T>
    {
        [XmlElement(ElementName = "ehr_system")]
        public InstanceIdentifier<T> EhrSystem { get; set; }

        [XmlElement(ElementName = "time_created")]
        public EHRDateTime TimeCreated { get; set; }

        [XmlElement(ElementName = "authorising_party")]
        public List<InstanceIdentifier<T>> AuthorisingParty { get; set; }

        [XmlAttribute(AttributeName = "rm_id")]
        public string RmId { get; set; }
    }
}
