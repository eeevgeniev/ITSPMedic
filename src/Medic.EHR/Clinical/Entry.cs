using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHR.Demographics.Base;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Entry<T> : Content<T> 
    {
        [XmlElement(ElementName = "subject_of_information_category")]
        public CodedValue<T> SubjectOfInformationCategory { get; set; }

        [XmlElement(ElementName = "information_provider")]
        public InstanceIdentifier<T> InformationProvider { get; set; }

        [XmlElement(ElementName = "items")]
        public List<Item<T>> Items { get; set; }

        [XmlElement(ElementName = "demographic_items")]
        public List<DemographicItem<T>> DemographicItems { get; set; } 
    }
}
