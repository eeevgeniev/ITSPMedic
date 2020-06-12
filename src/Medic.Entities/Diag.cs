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

        public int? ChemotherapyPartId { get; set; }

        public ChemotherapyPart ChemotherapyPart { get; set; }

        public InClinicProcedure FirstInClinicProcedure { get; set; } 

        public InClinicProcedure SecondInClinicProcedure { get; set; } 

        public PathProcedure FirstPathProcedure { get; set; } 

        public PathProcedure SecondPathProcedure { get; set; } 

        public ProtocolDrugTherapy ProtocolDrugTherapy { get; set; } 

        public CommissionApr CommissionAprMain { get; set; } 

        public int? CommissionAprId { get; set; }

        public CommissionApr CommissionApr { get; set; }

        public DispObservation FirstDispObservation { get; set; } 

        public DispObservation SecondDispObservation { get; set; } 

        public Transfer FirstPatientTransfer { get; set; }

        public Transfer SecondPatientTransfer { get; set; } 
    }
}