using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    [Serializable]
    public class SimpleText : EHRString
    {
        [XmlElement (ElementName = Constants.Language)]
        public CodedSimple Language { get; set; }
    }
}
