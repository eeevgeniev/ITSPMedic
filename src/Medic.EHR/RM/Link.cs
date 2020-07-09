using Medic.EHR.DataTypes;
using Medic.EHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.EHR.RM
{
    [Serializable]
    public class Link
    {
        [XmlElement(ElementName = Constants.Nature)]
        public CS Nature { get; set; }

        [XmlElement(ElementName = Constants.Role)]
        public CV Role { get; set; }

        [XmlElement(ElementName = Constants.FollowLink)]
        public bool FollowLink { get; set; } = false;

        [XmlElement(ElementName = Constants.Target)]
        public List<II> Target { get; set; }
    }
}
