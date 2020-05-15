using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class PatientTransfer
    {
        [XmlElement(ElementName = "Transfer")]
        public List<Transfer> Transfers { get; set; }
    }
}
