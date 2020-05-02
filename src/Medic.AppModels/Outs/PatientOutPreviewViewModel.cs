using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.Outs
{
    public class PatientOutPreviewViewModel
    {
        public int Id { get; set; }
        
        public DateTime OutDate { get; set; }

        public string MKBCode { get; set; }

        public string MKBName { get; set; }
    }
}
