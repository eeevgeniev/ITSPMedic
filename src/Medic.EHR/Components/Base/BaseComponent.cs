using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components.Base
{
    [Serializable]
    public abstract class BaseComponent
    {
        [XmlElement(ElementName = Constants.RcId)]
        public InstanceIdentifier RcId { get; set; }

        [XmlElement(ElementName = Constants.PreviousVersion)]
        public InstanceIdentifier PreviousVersion { get; set; }

        [XmlElement(ElementName = Constants.VersionSetId)]
        public InstanceIdentifier VersionSetId { get; set; }

        [XmlElement(ElementName = Constants.VersionStatus)]
        public CodedValue VersionStatus { get; set; }

        [XmlElement(ElementName = Constants.ReasonForRevision)]
        public CodedValue ReasonForRevision { get; set; }

        [XmlElement(ElementName = Constants.Audits)]
        public List<AuditInfo> Audits { get; set; }
    }
}
