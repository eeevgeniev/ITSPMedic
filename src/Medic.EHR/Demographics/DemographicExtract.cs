using Medic.EHR.Complexes;
using Medic.EHR.Infrastructure;
using Medic.EHR.Primitives;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.Demographics
{
    [Serializable]
    public class DemographicExtract : DemographicFolder
    {
        [XmlElement(ElementName = Constants.EhrSystem)]
        public InstanceIdentifier EhrSystem { get; set; }

        [XmlElement(ElementName = Constants.TimeCreated)]
        public EHRDateTime TimeCreated { get; set; }

        [XmlElement(ElementName = Constants.AuthorisingParty)]
        public List<InstanceIdentifier> AuthorisingParty { get; set; }

        [XmlAttribute(AttributeName = Constants.RmId)]
        public string RmId { get; set; }
    }
}
