using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> ClinicUsedDrug
    /// </summary>
    [Serializable]
    public partial class ClinicUsedDrug : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime DrugDate { get; set; }

        public string DrugCode { get; set; }

        public string DrugName { get; set; }

        public decimal DrugQuantity { get; set; }

        public decimal DrugCost { get; set; }

        public string ICDDrug { get; set; }

        public string UINPrescr { get; set; }

        public string NoPrescr { get; set; }

        public DateTime DatePrescr { get; set; }

        public string PracticeCodeProtocol { get; set; }

        public int ProtocolNumber { get; set; }

        public DateTime ProtocolDate { get; set; }

        public int ProtocolType { get; set; }

        public int? VersionCodeId { get; set; }

        public VersionCode VersionCode { get; set; }

        public int? PathProcedureId { get; set; }

        public PathProcedure PathProcedure { get; set; }
    }
}
