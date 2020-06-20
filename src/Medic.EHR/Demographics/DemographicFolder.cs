using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public class DemographicFolder : StructureComponent
    {
        [XmlElement(ElementName = Constants.Entities)]
        public List<DemographicEntity> Entities { get; set; }

        [XmlElement(ElementName = Constants.SubFolders)]
        public List<DemographicFolder> SubFolders { get; set; }
    }
}
