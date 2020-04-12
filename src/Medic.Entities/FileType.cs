using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    [Serializable]
    public partial class FileType : BaseEntity, IModelBuilder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CPFile> CPFiles { get; set; } = new HashSet<CPFile>();

        public ICollection<HospitalPractice> HospitalPractice { get; set; } = new HashSet<HospitalPractice>();
    }
}
