using Medic.EHR.Components;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    public class DemographicFolder<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = Constants.Entities)]
        public List<DemographicEntity<T>> Entities { get; set; }

        [XmlElement(ElementName = Constants.SubFolders)]
        public List<DemographicFolder<T>> SubFolders { get; set; }
    }
}
