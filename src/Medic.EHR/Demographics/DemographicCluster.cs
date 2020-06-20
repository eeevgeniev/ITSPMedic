using Medic.EHR.Demographics.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public class DemographicCluster : DemographicItem
    {
        [XmlElement(ElementName = Constants.Parts)]
        public List<DemographicItem> Parts { get; set; }
    }
}
