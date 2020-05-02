using System;

namespace Medic.AppModels.Procedures
{
    public class ProcedureSummaryViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Code { get; set; }

        public string ACHICode { get; set; }

        public int OutHospital { get; set; }

        public string ImplantReferenceNumber { get; set; }

        public string ImplantManufacturer { get; set; }

        public string ImplantCode { get; set; }

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
    }
}
