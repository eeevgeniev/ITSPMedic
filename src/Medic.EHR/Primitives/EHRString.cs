using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives.Base;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Primitives
{
    [Serializable]
    public class EHRString : EHRDataValue
    {
        [XmlAttribute(AttributeName = Constants.Value)]
        public virtual string Value { get; set; }
    }
}
