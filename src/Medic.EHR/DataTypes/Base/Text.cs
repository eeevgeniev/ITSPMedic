using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes.Base
{
    [Serializable]
    public abstract class Text : DataValue
    {
        [XmlElement(ElementName = Constants.OriginalText)]
        public string OriginalText { get; set; }

        [XmlElement(ElementName = Constants.Language)]
        public CS Language { get; set; }

        [XmlElement(ElementName = Constants.Charset)]
        public CS Charset { get; set; }
    }
}