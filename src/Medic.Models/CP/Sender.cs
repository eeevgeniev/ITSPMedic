﻿using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Sender
    {
        public Practice Practice { get; set; }

        [XmlElement(ElementName = "uin")]
        public string UniqueIdentifier { get; set; }

        [XmlElement(ElementName = "deputyUin")]
        public string DeputyUniqueIdentifier { get; set; }

        [XmlElement(ElementName = "speciality")]
        public int? Speciality { get; set; }

        [XmlElement(ElementName = "NumNapr")]
        public int ClinicalNumber { get; set; }
    }
}