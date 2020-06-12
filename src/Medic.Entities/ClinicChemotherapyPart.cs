using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> ClinicChemotherapyPart
    /// </summary>
    [Serializable]
    public partial class ClinicChemotherapyPart : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int ECOG { get; set; }

        public string TNM { get; set; }

        public int? EvalutionId { get; set; }

        public Evaluation Evaluation { get; set; }

        public int? DecisionId { get; set; }

        public Evaluation Decision { get; set; }

        public ICollection<APr05> APr05s { get; set; } = new HashSet<APr05>();
    }
}