using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    public partial class DrugResidue : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime? DrugDate { get; set; }

        public string DrugCode { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? DrugCost { get; set; }

        public string ProductCode { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string BatchNumber { get; set; }

        public string SerialNumber { get; set; }

        public int? CPFileId { get; set; }

        public CPFile CPFile { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }
    }
}
