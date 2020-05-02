using System;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugSummaryViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Code { get; set; }

        public decimal Quantity { get; set; }

        public decimal Cost { get; set; }

        public string ICDDrug { get; set; }

        public string UINPrescr { get; set; }

        public string NoPrescr { get; set; }

        public DateTime? DatePrescr { get; set; }

        public string PracticeCodeProtocol { get; set; }

        public int ProtocolNumber { get; set; }

        public DateTime ProtocolDate { get; set; }

        public int ProtocolType { get; set; }

        public string BatchNumber { get; set; }

        public decimal QuantityPack { get; set; }
    }
}
