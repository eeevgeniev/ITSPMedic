using Medic.EHR.Complexes;
using Medic.EHR.Components;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    public class Folder<T> : StructureComponent<T>
    {
        [XmlElement(ElementName = "subject_of_care")]
        public InstanceIdentifier<T> SubjectOfCare { get; set; }

        [XmlElement(ElementName = "sub_folders")]
        public List<Folder<T>> SubFolders { get; set; }

        [XmlElement(ElementName = "compositions")]
        public List<Composition<T>> Compositions { get; set; }
    }
}
