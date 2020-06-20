using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    [Serializable]
    public class Composition : StructureComponent
    {
        [XmlElement(ElementName = Constants.Composer)]
        public InstanceIdentifier Composer { get; set; }

        [XmlElement(ElementName = Constants.PolicyIds)]
        public List<InstanceIdentifier> PolicyIds { get; set; }

        [XmlElement(ElementName = Constants.Content)]
        public List<Content> Content { get; set; }

        [XmlAttribute(AttributeName = Constants.Sensitivity)]
        public string Sensitivity { get; set; }
    }
}
