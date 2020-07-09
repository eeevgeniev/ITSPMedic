using Medic.EHR.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class ReferenceModel
    {
        [XmlElement(ElementName = Constants.Folder)]
        public Folder Folder { get; set; }

        [XmlElement(ElementName = Constants.Composition)]
        public Composition Composition { get; set; }
    }
}
