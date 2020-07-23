using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Folder : RecordComponent
    {
        [XmlElement(ElementName = Constants.SubFolders)]
        [JsonProperty(Constants.SubFolders)]
        public List<Folder> SubFolders { get; set; }

        [XmlElement(ElementName = Constants.Attestations)]
        [JsonProperty(Constants.Attestations)]
        public List<AttestationInfo> Attestations { get; set; }

        [XmlElement(ElementName = Constants.Compositions)]
        [JsonProperty(Constants.Compositions)]
        public List<II> Compositions { get; set; }
    }
}
