﻿using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    public class RTO : Quantity
    {
        [XmlElement(ElementName = Constants.Numerator)]
        public PQ Numerator { get; set; }

        [XmlElement(ElementName = Constants.Denominator)]
        public PQ Denominator { get; set; }
    }
}
