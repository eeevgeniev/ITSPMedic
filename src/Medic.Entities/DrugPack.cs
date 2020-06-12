using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    public partial class DrugPack : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }
        
        public DateTime? DrugDate { get; set; }

        public string DrugCode { get; set; }

        public decimal? DrugQuantity { get; set; }

        public string BatchNumber { get; set; }

        public string ProductCode { get; set; }

        public string ExpireDateAsString { get; set; }

        public string SerialNumber { get; set; }

        public int CPFileId { get; set; }
        
        public CPFile CPFile { get; set; }

        public int HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }
    }
}
