using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class SimpleText : EHRString
    {
        [XmlElement (ElementName = "language")]
        public CodedSimple Language { get; set; }
    }
}
