using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical.Base
{
    [Serializable]
    [XmlInclude(typeof(Element))]
    [XmlInclude(typeof(Cluster))]
    public abstract class Item : StructureComponent
    {
        [XmlElement(ElementName = Constants.Emphasis)]
        public CodedValue Emphasis { get; set; }
    }
}