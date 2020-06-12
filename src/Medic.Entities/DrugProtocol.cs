using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> DrugProtocol
    /// </summary>
    [Serializable]
    public partial class DrugProtocol : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? TherapyTypeId { get; set; }

        public TherapyType TherapyType { get; set; }

        public string ATCCode { get; set; }

        public string ATCName { get; set; }

        public string Days { get; set; }

        public int? NumberOfDays { get; set; }

        public string ApplicationWay { get; set; }

        public decimal StandartDose { get; set; }

        public decimal IndividualDose { get; set; }

        public decimal CycleDose { get; set; }

        public decimal AllDose { get; set; }

        public int? ProtocolDrugTherapyId { get; set; }

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; }
    }
}
