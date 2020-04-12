using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> AccompanyingDrug
    /// </summary>
    [Serializable]
    public partial class AccompanyingDrug : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? TherapyTypeId { get; set; }

        public TherapyType TherapyType { get; set; }

        public string ATCCode { get; set; }

        public string ATCName { get; set; }

        public decimal SingleDose { get; set; }

        public decimal AllDose { get; set; }

        public int? ProtocolDrugTherapyId { get; set; }

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; }
    }
}
