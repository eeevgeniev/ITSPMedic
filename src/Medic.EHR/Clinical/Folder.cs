using Medic.EHR.Complexes;
using Medic.EHR.Components;
using Medic.EHR.Infrastructure;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Folder<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = Constants.SubjectOfCare)]
        public InstanceIdentifier<T> SubjectOfCare { get; set; }

        [XmlElement(ElementName = Constants.SubFolders)]
        public List<Folder<T>> SubFolders { get; set; }

        [XmlElement(ElementName = Constants.Compositions)]
        public List<Composition<T>> Compositions { get; set; }
    }
}
