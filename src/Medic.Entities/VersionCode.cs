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

        public decimal QuantityPack { get; set; }

        public ClinicUsedDrug ClinicUsedDrug { get; set; }
    }
}
