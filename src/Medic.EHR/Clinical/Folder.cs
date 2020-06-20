using Medic.EHR.Complexes;
using Medic.EHR.Components.Base;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Clinical
{
    [Serializable]
    public class Folder : StructureComponent
    {
        [XmlElement(ElementName = Constants.SubjectOfCare)]
        public InstanceIdentifier SubjectOfCare { get; set; }

        [XmlElement(ElementName = Constants.SubFolders)]
        public List<Folder> SubFolders { get; set; }

        [XmlElement(ElementName = Constants.Compositions)]
        public List<Composition> Compositions { get; set; }
    }
}
