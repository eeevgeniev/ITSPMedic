using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    public class URI : EHRString
    {
        [XmlAttribute(AttributeName = Constants.Description)]
        public string Description { get; set; }
    }
}
