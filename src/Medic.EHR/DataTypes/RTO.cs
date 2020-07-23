using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class RTO : Quantity
    {
        [XmlElement(ElementName = Constants.Numerator)]
        [JsonProperty(Constants.Numerator)]
        public PQ Numerator { get; set; }

        [XmlElement(ElementName = Constants.Denominator)]
        [JsonProperty(Constants.Denominator)]
        public PQ Denominator { get; set; }
    }
}
