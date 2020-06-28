using Medic.EHR.Infrastructure;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    public class ReferenceModel
    {
        [XmlElement(ElementName = Constants.Folder)]
        public Folder Folder { get; set; }

        [XmlElement(ElementName = Constants.Composition)]
        public Composition Composition { get; set; }
    }
}
