using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System;

namespace Medic.Entities
{
    [Serializable]
    public partial class HealthcarePractitionerEpicrisis : BaseEntity, IModelBuilder
    {
        public int HealthcarePractitionerId { get; set; }

        public HealthcarePractitioner HealthcarePractitioner { get; set; }

        public int EpicrisisId { get; set; }

        public Epicrisis Epicrisis { get; set; }
    }
}