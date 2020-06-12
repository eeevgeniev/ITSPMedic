using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> ClinicHematologyPart
    /// </summary>
    [Serializable]
    public partial class ClinicHematologyPart : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set;  }

        public string StageHemo { get; set; }

        public int OngoingTherapy { get; set; }

        public int? EvalutionId { get; set; }

        public Evaluation Evaluation { get; set; }

        public int? DecisionId { get; set; }

        public Evaluation Decision { get; set; }

        public ICollection<APr05> APr05s { get; set; } = new HashSet<APr05>();
    }
}