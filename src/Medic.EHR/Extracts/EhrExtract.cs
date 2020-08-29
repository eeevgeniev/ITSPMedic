using Medic.EHR.DataTypes;
using Medic.EHR.Demographics;
using Medic.EHR.Infrastructure;
using Medic.EHR.RM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Extracts
{
    [Serializable]
    [XmlRoot(ElementName = Constants.EhrExtract)]
    public class EhrExtract
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        [JsonProperty(Constants.EhrSystem)]
        public II EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.EhrId)]
        [JsonProperty(Constants.EhrId)]
        public II EhrId { get; set; }

        [XmlElement(ElementName = Constants.SubjectOfCare)]
        [JsonProperty(Constants.SubjectOfCare)]
        public II SubjectOfCare { get; set; }

        [XmlElement(ElementName = Constants.TimeCreated)]
        [JsonProperty(Constants.TimeCreated)]
        public TS TimeCreated { get; set; }

        [XmlElement(ElementName = Constants.AuthorisingParty)]
        [JsonProperty(Constants.AuthorisingParty)]
        public II AuthorisingParty { get; set; }

        [XmlElement(ElementName = Constants.RmId)]
        [JsonProperty(Constants.RmId)]
        public string RmId { get; set; }

        [XmlElement(ElementName = Constants.Folders)]
        [JsonProperty(Constants.Folders)]
        public List<Folder> Folders { get; set; }

        [XmlElement(ElementName = Constants.AllCompositions)]
        [JsonProperty(Constants.AllCompositions)]
        public List<Composition> AllCompositions { get; set; }

        [XmlElement(ElementName = Constants.Criteria)]
        [JsonProperty(Constants.Criteria)]
        public ExtractCriteria Criteria { get; set; }

        [XmlElement(ElementName = Constants.IdentifiedEntity)]
        [JsonProperty(Constants.IdentifiedEntity)]
        public IdentifiedEntity DemographicExtract { get; set; }
    }
}
