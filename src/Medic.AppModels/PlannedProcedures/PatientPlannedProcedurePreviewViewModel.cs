using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.PlannedProcedures
{
    public class PatientPlannedProcedurePreviewViewModel
    {
        public DateTime ExaminationDate { get; set; }

        public string MKBCode { get; set; }

        public string MKBName { get; set; }
    }
}
