using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System;

namespace Medic.Entities
{
    [Serializable]
    public partial class CommissionAprHealthcarePractitioner: BaseEntity, IModelBuilder
    {
        public int HealthcarePractitionerId { get; set; }

        public HealthcarePractitioner HealthcarePractitioner { get; set; }

        public int CommissionAprId { get; set; }

        public CommissionApr CommissionApr { get; set; }
    }
}
