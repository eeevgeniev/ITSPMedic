using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Entry : Content
    {
        [XmlElement(ElementName = Constants.ActId)]
        public string ActId { get; set; }

        [XmlElement(ElementName = Constants.ActStatus)]
        public CS ActStatus { get; set; }

        [XmlElement(ElementName = Constants.UncertaintyExpressed)]
        public bool UncertaintyExpressed { get; set; } = false;

        [XmlElement(ElementName = Constants.SubjectOfInformationCategory)]
        public CS SubjectOfInformationCategory { get; set; }

        [XmlElement(ElementName = Constants.InfoProvider)]
        public FunctionalRole InfoProvider { get; set; }

        [XmlElement(ElementName = Constants.SubjectOfInformation)]
        public RelatedParty SubjectOfInformation { get; set; }

        [XmlElement(ElementName = Constants.OtherParticipations)]
        public List<FunctionalRole> OtherParticipations { get; set; }

        [XmlElement(ElementName = Constants.Items)]
        public List<Item> Items { get; set; }
    }
}
