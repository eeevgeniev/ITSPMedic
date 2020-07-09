using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class TS : DataValue
    {
        [XmlElement(ElementName = Constants.Time)]
        public DateTime Time { get; set; }
    }
}
