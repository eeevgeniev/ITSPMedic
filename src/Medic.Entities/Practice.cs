using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Practice
    /// </summary>
    [Serializable]
    public partial class Practice : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int Branch { get; set; }

        public string Number { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? HealthRegionId { get; set; }

        public HealthRegion HealthRegion { get; set; }

        public string Address { get; set; }

        public ICollection<CPFile> CPFiles { get; set; } = new HashSet<CPFile>();

        public ICollection<HospitalPractice> HospitalPractices { get; set; } = new HashSet<HospitalPractice>();

        public ICollection<HealthcarePractitioner> HealthcarePractitioners { get; set; } = new HashSet<HealthcarePractitioner>();
    }
}