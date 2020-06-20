using Medic.EHR.Components.Base;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical.Base
{
    [Serializable]
    [XmlInclude(typeof(Entry))]
    [XmlInclude(typeof(Section))]
    public abstract class Content : StructureComponent
    {

    }
}
