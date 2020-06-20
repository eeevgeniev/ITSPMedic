using Medic.EHR.Clinical;
using Medic.EHR.Complexes;
using Medic.EHR.Demographics;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Components
{
    [Serializable]
    [XmlRoot(ElementName = Constants.EhrExtract)]
    public class EHRExtract : Folder
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        public InstanceIdentifier EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.EhrId)]
        public InstanceIdentifier EhrId { get; set; }

        [XmlElement(ElementName = Constants.TimeCreated)]
        public EHRDateTime TimeCreated { get; set; }

        [XmlElement(ElementName = Constants.AuthorisingParty)]
        public List<InstanceIdentifier> AuthorisingParty { get; set; }

        [XmlElement(ElementName = Constants.AccessPolicyIds)]
        public List<string> AccessPolicyIds { get; set; }

        [XmlElement(ElementName = Constants.Components)]
        public ExtractedComponentSet Components { get; set; }

        [XmlElement(ElementName = Constants.Demographics)]
        public DemographicExtract Demographics { get; set; }

        [XmlAttribute(AttributeName = Constants.RmId)]
        public string RmId { get; set; }
    }
}
