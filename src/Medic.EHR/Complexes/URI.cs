using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    [Serializable]
    public class URI : EHRString
    {
        [XmlAttribute(AttributeName = Constants.Description)]
        public string Description { get; set; }
    }
}
