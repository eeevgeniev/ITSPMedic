using Medic.EHR.Complexes;
using System;
using System.Xml.Serialization;

namespace Medic.EHR.Primitives.Base
{
    [Serializable]
    [XmlInclude(typeof(EHRBoolean))]
    [XmlInclude(typeof(EHRDate))]
    [XmlInclude(typeof(EHRDateTime))]
    [XmlInclude(typeof(EHRInteger))]
    [XmlInclude(typeof(EHRPointInTime))]
    [XmlInclude(typeof(EHRReal))]
    [XmlInclude(typeof(EHRString))]
    [XmlInclude(typeof(EHRTime))]
    [XmlInclude(typeof(CodedValue))]
    public abstract class EHRDataValue
    {
        
    }
}