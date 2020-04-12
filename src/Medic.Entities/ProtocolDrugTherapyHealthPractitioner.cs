using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System;

namespace Medic.Entities
{
    [Serializable]
    public partial class ProtocolDrugTherapyHealthPractitioner : BaseEntity, IModelBuilder
    {
        public int HealthcarePractitionerId { get; set; }

        public HealthcarePractitioner HealthcarePractitioner { get; set; }

        public int ProtocolDrugTherapyId { get; set; }

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; }
    }
}