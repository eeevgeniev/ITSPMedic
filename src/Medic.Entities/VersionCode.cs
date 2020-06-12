using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> VersionCode
    /// </summary>
    [Serializable]
    public partial class VersionCode : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string BatchNumber { get; set; }

        public string ProductCode { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string SerialNumber { get; set; }

        public string DataMatrix { get; set; }

        public decimal QuantityPack { get; set; }

        public ClinicUsedDrug ClinicUsedDrug { get; set; }
    }
}
