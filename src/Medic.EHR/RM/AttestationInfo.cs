using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class AttestationInfo
    {
        [XmlElement(ElementName = Constants.Time)]
        public TS Time { get; set; }

        [XmlElement(ElementName = Constants.Proof)]
        public ED Proof { get; set; }

        [XmlElement(ElementName = Constants.AttestedView)]
        public ED AttestedView { get; set; }

        [XmlElement(ElementName = Constants.ReasonForAttestation)]
        public CV ReasonForAttestation { get; set; }

        [XmlElement(ElementName = Constants.Attester)]
        public FunctionalRole Attester { get; set; }

        [XmlElement(ElementName = Constants.Target)]
        public List<II> Target { get; set; }
    }
}
