using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class Evaluation
    {
        [XmlElement(ElementName = "Choise")]
        public List<Choice> Choices { get; set; }
    }
}