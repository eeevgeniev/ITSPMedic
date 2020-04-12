using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Evaluation
    /// CP -> PredMarker
    /// </summary>
    [Serializable]
    public partial class Evaluation : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public ICollection<Choise> Choises { get; set; } = new HashSet<Choise>();

        public ChemotherapyPart ChemotherapyPart { get; set; }

        public HematologyPart HematologyPart { get; set; }

        public int? ClinicChemotherapyPartId { get; set; }

        public ClinicChemotherapyPart ClinicChemotherapyPart { get; set; }

        public int? ClinicHematologyPartId { get; set; }

        public ClinicHematologyPart ClinicHematologyPart { get; set; }

        public APr38 APr38s { get; set; }

        public ClinicChemotherapyPart ClinicChemotherapyPartDecision { get; set;}

        public ClinicHematologyPart ClinicHematologyPartDecision { get; set; }
    }
}