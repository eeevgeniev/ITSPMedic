using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Procedure
    /// CLPR -> DoneNewProcedure
    /// </summary>
    [Serializable]
    public partial class Procedure : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Code { get; set; }

        public string ACHICode { get; set; }

        public int OutHospital { get; set; }

        public int? ImplantId { get; set; }

        public Implant Implant { get; set; }

        public int BedDays { get; set; }

        public DateTime? HLDateFrom { get; set; }

        public string HLNumber { get; set; }

        public int HLTotalDays { get; set; }

        public int StateAtDischarge { get; set; }

        public int Laparoscopic { get; set; }

        public int PathologicFinding { get; set; }

        public int EndCourse { get; set; }

        public string SendAPr { get; set; }

        public string InAPr { get; set; }

        public int? OutId { get; set; }

        public Out Out { get; set; }

        public int? PathProcedureId { get; set; }

        public PathProcedure PathProcedure { get; set; }
    }
}