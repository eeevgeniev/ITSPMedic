using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    [Serializable]
    public partial class Provider : BaseEntity, IModelBuilder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Code { get; set; }

        public ICollection<Implant> Implants { get; set; } = new HashSet<Implant>();
    }
}
