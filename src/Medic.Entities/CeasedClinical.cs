using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> CeasedClinical
    /// </summary>
    [Serializable]
    public partial class CeasedClinical : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int IZMedicalWard { get; set; }

        public int IZYearMedicalWard { get; set; }

        public PathProcedure PathProcedure { get; set; }

        public PathProcedure PathProcedurePath { get; set; }

        public PathProcedure CeasedOnlyPathProcedure { get; set; }

        public InClinicProcedure CeasedClinicalPathInClinicProcedure { get; set; }

        public InClinicProcedure CeasedProcedureInClinicProcedure { get; set; }

        public InClinicProcedure CeasedOnlyInClinicProcedure { get; set; }
    }
}