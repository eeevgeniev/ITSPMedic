using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    public partial class Transfer : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int IZYear { get; set; }

        public int IZNumber { get; set; }

        public int? FirstMainDiagId { get; set; }

        public Diag FirstMainDiag { get; set; }

        public int? SecondMainDiagId { get; set; }

        public Diag SecondMainDiag { get; set; }

        public int CashPatient { get; set; }

        public int ClinicalProcedure { get; set; }

        public double ClinicalPath { get; set; }

        public double DischargeWard { get; set; }

        public double TransferWard { get; set; }

        public DateTime? TransferDateTime { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }

        public int? CPFileId { get; set; }

        public CPFile CPFile { get; set; }
    }
}
