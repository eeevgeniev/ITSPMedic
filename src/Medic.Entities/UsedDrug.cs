using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> UsedDrug
    /// </summary>
    [Serializable]
    public partial class UsedDrug : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Code { get; set; }

        public decimal Quantity { get; set; }

        public decimal Cost { get; set; }

        public string ICDDrug { get; set; }

        public string UINPrescr { get; set; }

        public string NoPrescr { get; set; }

        public DateTime? DatePrescr { get; set; }

        public string PracticeCodeProtocol { get; set; }

        public int ProtocolNumber { get; set; }

        public DateTime ProtocolDate { get; set; }

        public int ProtocolType { get; set; }

        public VersionCode VersionCode { get; set; }

        public int OutId { get; set; }

        public Out Out { get; set; }
    }
}