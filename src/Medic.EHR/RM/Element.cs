using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Element : Item
    {
        [XmlElement(ElementName = Constants.Value)]
        public DataValue Value { get; set; }
    }
}