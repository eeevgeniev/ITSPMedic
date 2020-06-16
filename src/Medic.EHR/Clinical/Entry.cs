using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHR.Demographics.Base;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Entry<T> : Content<T> 
    {
        [XmlElement(ElementName = Constants.SubjectOfInformationCategory)]
        public CodedValue<T> SubjectOfInformationCategory { get; set; }

        [XmlElement(ElementName = Constants.InformationProvider)]
        public InstanceIdentifier<T> InformationProvider { get; set; }

        [XmlElement(ElementName = Constants.Items)]
        public List<Item<T>> Items { get; set; }

        [XmlElement(ElementName = Constants.DemographicItems)]
        public List<DemographicItem<T>> DemographicItems { get; set; } 
    }
}
