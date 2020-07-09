using Medic.EHR.DataTypes.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.DataTypes
{
    [Serializable]
    public class CodedText : Text
    {
        [XmlElement(ElementName = Constants.CodedValue)]
        public CD CodedValue { get; set; }
    }
}
