using Medic.EHR.Clinical.Base;
using Medic.EHR.Complexes;
using Medic.EHR.Components;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Composition<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = Constants.Composer)]
        public InstanceIdentifier<T> Composer { get; set; }

        [XmlElement(ElementName = Constants.PolicyIds)]
        public List<InstanceIdentifier<T>> PolicyIds { get; set; }

        [XmlElement(ElementName = Constants.Content)]
        public List<Content<T>> Content { get; set; }

        [XmlAttribute(AttributeName = Constants.Sensitivity)]
        public int? Sensitivity { get; set; }
    }
}
