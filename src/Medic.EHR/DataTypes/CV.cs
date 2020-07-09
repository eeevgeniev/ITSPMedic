using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class CV : CS
    {
        [XmlElement(ElementName = Constants.DisplayName)]
        public string DisplayName { get; set; }
    }
}
