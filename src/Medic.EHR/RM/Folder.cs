using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Folder : RecordComponent
    {
        [XmlElement(ElementName = Constants.SubFolders)]
        public List<Folder> SubFolders { get; set; }

        [XmlElement(ElementName = Constants.Attestations)]
        public List<AttestationInfo> Attestations { get; set; }

        [XmlElement(ElementName = Constants.Compositions)]
        public List<II> Compositions { get; set; }
    }
}
