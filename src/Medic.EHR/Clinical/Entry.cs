using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHR.Demographics.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    [Serializable]
    public class Entry : Content
    {
        [XmlElement(ElementName = Constants.SubjectOfInformationCategory)]
        public CodedValue SubjectOfInformationCategory { get; set; }

        [XmlElement(ElementName = Constants.InformationProvider)]
        public InstanceIdentifier InformationProvider { get; set; }

        [XmlElement(ElementName = Constants.Items)]
        public List<Item> Items { get; set; }

        [XmlElement(ElementName = Constants.DemographicItems)]
        public List<DemographicItem> DemographicItems { get; set; } 
    }
}
