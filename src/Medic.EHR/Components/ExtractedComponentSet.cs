using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    [Serializable]
    public class ExtractedComponentSet
    {
        [XmlElement(ElementName = Constants.StructureComponents)]
        public List<StructureComponent> StructureComponents { get; set; }
    }
}