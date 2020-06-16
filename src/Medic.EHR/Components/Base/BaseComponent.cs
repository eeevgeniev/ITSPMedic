using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components.Base
{
    public abstract class BaseComponent<T>
    {
        [XmlElement(ElementName = Constants.RcId)]
        public InstanceIdentifier<T> RcId { get; set; }

        [XmlElement(ElementName = Constants.PreviousVersion)]
        public InstanceIdentifier<T> PreviousVersion { get; set; }

        [XmlElement(ElementName = Constants.VersionSetId)]
        public InstanceIdentifier<T> VersionSetId { get; set; }

        [XmlElement(ElementName = Constants.VersionStatus)]
        public CodedValue<T> VersionStatus { get; set; }

        [XmlElement(ElementName = Constants.ReasonForRevision)]
        public CodedValue<T> ReasonForRevision { get; set; }

        [XmlElement(ElementName = Constants.Audits)]
        public List<AuditInfo<T>> Audits { get; set; }
    }
}
