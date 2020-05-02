using System;

namespace Medic.AppModels.Ins
{
    public class PatientInPreviewViewModel
    {
        public int Id { get; set; }
        
        public DateTime EntryDate { get; set; }

        public string MKBCode { get; set; }

        public string MKBName { get; set; }
    }
}