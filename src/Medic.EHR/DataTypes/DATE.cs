using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class DATE : DataValue
    {
        [XmlElement(ElementName = Constants.Date)]
        public DateTime Date { get; set; }
    }
}
