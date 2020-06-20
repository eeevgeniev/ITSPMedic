using Medic.EHR.Components.Base;
using Medic.EHR.Demographics.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public class DemographicEntity : StructureComponent
    {
        [XmlElement(ElementName = Constants.Items)]
        public List<DemographicItem> Items { get; set; }
    }
}
