using Medic.EHR.Components;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicFolder<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = "entities")]
        public List<DemographicEntity<T>> Entities { get; set; }

        [XmlElement(ElementName = "sub_folders")]
        public List<DemographicFolder<T>> SubFolders { get; set; }
    }
}
