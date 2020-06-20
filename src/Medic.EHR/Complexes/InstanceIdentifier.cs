using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives.Base;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Complexes
{
    [Serializable]
    public class InstanceIdentifier : EHRDataValue
    {
        [XmlAttribute(AttributeName = Constants.Root)]
        public string Root { get; set; }

        [XmlAttribute(AttributeName = Constants.Extension)]
        public string Extension { get; set; }

        [XmlAttribute(AttributeName = Constants.IdentifierName)]
        public string IdentifierName { get; set; }
    }
}
