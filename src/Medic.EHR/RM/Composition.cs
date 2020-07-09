using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Composition : RecordComponent
    {
        [XmlElement(ElementName = Constants.SessionTime)]
        public IVLTS SessionTime { get; set; }

        [XmlElement(ElementName = Constants.Territory)]
        public CS Territory { get; set; }

        [XmlElement(ElementName = Constants.ContributionId)]
        public II ContributionId { get; set; }

        [XmlElement(ElementName = Constants.Committal)]
        public AuditInfo Committal { get; set; }

        [XmlElement(ElementName = Constants.Composer)]
        public FunctionalRole Composer { get; set; }

        [XmlElement(ElementName = Constants.OtherParticipation)]
        public List<FunctionalRole> OtherParticipation { get; set; }

        [XmlElement(ElementName = Constants.Attestations)]
        public List<AttestationInfo> Attestations { get; set; }

        [XmlElement(ElementName = Constants.Content)]
        public List<Content> Content { get; set; }
    }
}
