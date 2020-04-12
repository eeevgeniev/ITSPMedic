using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> ClinicProcedure
    /// </summary>
    [Serializable]
    public partial class ClinicProcedure : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string ProcedureName { get; set; }

        public decimal ProcedureCode { get; set; }

        public DateTime ProcedureDate { get; set; }

        public string ACHIcode { get; set; }

        public int? PathProcedureId { get; set; }
        
        public PathProcedure PathProcedure { get; set; }
    }
}