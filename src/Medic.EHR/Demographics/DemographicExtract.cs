using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicExtract<T> : DemographicFolder<T>
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        public InstanceIdentifier<T> EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.TimeCreated)]
        public EHRDateTime TimeCreated { get; set; }

        [XmlElement(ElementName = Constants.AuthorisingParty)]
        public List<InstanceIdentifier<T>> AuthorisingParty { get; set; }

        [XmlAttribute(AttributeName = Constants.RmId)]
        public string RmId { get; set; }
    }
}
