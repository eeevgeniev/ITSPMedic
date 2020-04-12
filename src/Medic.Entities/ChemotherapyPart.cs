using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> ChemotherapyPart
    /// </summary>
    [Serializable]
    public partial class ChemotherapyPart : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime DiagnoseDate { get; set; }

        public string ExpandDiagnose { get; set; }

        public int? AddDiagId { get; set; }

        public Diag AddDiag { get; set; }

        public int? HistologyId { get; set; }

        public Histology Histology { get; set; }

        public int ECOG { get; set; }

        public string Staging { get; set; }

        public string TNM { get; set; }

        public ICollection<GenMarker> GenMarkers { get; set; } = new HashSet<GenMarker>();

        public int TherapyType { get; set; }

        public int EvalAfterCycle { get; set; }

        public int Interval { get; set; }

        public int? EvaluationId { get; set; }

        public Evaluation Evaluation { get; set; }

        public int? ProtocolDrugTherapyId { get; set; }

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; }
    }
}