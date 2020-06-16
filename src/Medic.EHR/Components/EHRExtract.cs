using Medic.EHR.Clinical;
using Medic.EHR.Complexes;
using Medic.EHR.Demographics;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    public class EHRExtract<T> : Folder<T>
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        public InstanceIdentifier<T> EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.EhrId)]
        public InstanceIdentifier<T> EhrId { get; set; }

        [XmlElement(ElementName = Constants.TimeCreated)]
        public EHRDateTime TimeCreated { get; set; }

        [XmlElement(ElementName = Constants.AuthorisingParty)]
        public List<InstanceIdentifier<T>> AuthorisingParty { get; set; }

        [XmlElement(ElementName = Constants.AccessPolicyIds)]
        public List<string> AccessPolicyIds { get; set; }

        [XmlElement(ElementName = Constants.Components)]
        public ExtractedComponentSet<T> Components { get; set; }

        [XmlElement(ElementName = Constants.Demographics)]
        public DemographicExtract<T> Demographics { get; set; }

        [XmlAttribute(AttributeName = Constants.RmId)]
        public string RmId { get; set; }
    }
}
