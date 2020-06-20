using Medic.EHR.Clinical.Base;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives.Base;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    [Serializable]
    public class Element : Item
    {
        [XmlElement(ElementName = Constants.Value)]
        public EHRDataValue Value { get; set; }
    }
}
