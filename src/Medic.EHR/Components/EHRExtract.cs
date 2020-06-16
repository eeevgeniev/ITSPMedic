using Medic.EHR.Clinical;
using Medic.EHR.Complexes;
using Medic.EHR.Demographics;
using Medic.EHR.Primitives;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class EHRExtract<T> : Folder<T>
    {
        [XmlElement(ElementName = "ehr_system")]
        public InstanceIdentifier<T> EhrSystem { get; set; }

        [XmlElement(ElementName = "ehr_id")]
        public InstanceIdentifier<T> EhrId { get; set; }

        [XmlElement(ElementName = "time_created")]
        public EHRDateTime TimeCreated { get; set; }

        [XmlElement(ElementName = "authorising_party")]
        public List<InstanceIdentifier<T>> AuthorisingParty { get; set; }

        [XmlElement(ElementName = "access_policy_id")]
        public List<string> AccessPolicyIds { get; set; }

        [XmlElement(ElementName = "components")]
        public ExtractedComponentSet<T> Components { get; set; }

        [XmlElement(ElementName = "demographics")]
        public DemographicExtract<T> Demographics { get; set; }

        [XmlAttribute(AttributeName = "rm_id")]
        public string RmId { get; set; }
    }
}
