using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Diag
    /// CP -> AddDiag
    /// </summary>
    [Serializable]
    public partial class Diag : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string ImeMD { get; set; }

        public string MKBCode { get; set; }

        public MKB MKB { get; set; }

        public string LinkDName { get; set; }

        public string LinkDMKBCode { get; set; }

        public MKB LinkDMKB { get; set; }

        public ChemotherapyPart ChemotherapyPart { get; set; } //added

        public InClinicProcedure FirstInClinicProcedure { get; set; } // added

        public InClinicProcedure SecondInClinicProcedure { get; set; } // added

        public PathProcedure FirstPathProcedure { get; set; } // added

        public PathProcedure SecondPathProcedure { get; set; } // added

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; } // added

        public CommissionApr CommissionAprMain { get; set; } // added

        public int? CommissionAprId { get; set; }

        public CommissionApr CommissionApr { get; set; } // added

        public DispObservation FirstDispObservation { get; set; } // added

        public DispObservation SecondDispObservation { get; set; } // added

        public Transfer FirstPatientTransfer { get; set; } // added

        public Transfer SecondPatientTransfer { get; set; } // added
    }
}