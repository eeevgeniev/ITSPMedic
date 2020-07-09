using Medic.EHR.DataTypes;
using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM.Base
{
    [Serializable]
    public abstract class RecordComponent
    {
        [XmlElement(ElementName = Constants.Name)]
        public Text Name { get; set; }

        [XmlElement(ElementName = Constants.ArchetypeId)]
        public string ArchetypeId { get; set; }

        [XmlElement(ElementName = Constants.RcId)]
        public II RcId { get; set; }

        [XmlElement(ElementName = Constants.Meaning)]
        public CV Meaning { get; set; }

        [XmlElement(ElementName = Constants.Synthesised)]
        public bool Synthesised { get; set; } = false;

        [XmlElement(ElementName = Constants.PolicyIds)]
        public List<II> PolicyIds { get; set; }

        [XmlElement(ElementName = Constants.Sensitivity)]
        public int? Sensitivity { get; set; }

        [XmlElement(ElementName = Constants.OrigParentRef)]
        public II OrigParentRef { get; set; }

        [XmlElement(ElementName = Constants.Links)]
        public List<Link> Links { get; set; }

        [XmlElement(ElementName = Constants.FeederAudit)]
        public AuditInfo FeederAudit { get; set; }
    }
}
