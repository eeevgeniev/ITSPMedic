using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class PIVL : DataValue
    {
        [XmlElement(ElementName = Constants.Phase)]
        public IVLTS Phase { get; set; }

        [XmlElement(ElementName = Constants.Period)]
        public Duration Period { get; set; }

        [XmlElement(ElementName = Constants.Alignment)]
        public CD Alignment { get; set; }
    }
}
