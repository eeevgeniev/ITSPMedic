using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System.Collections.Generic;

namespace Medic.Entities
{
    public partial class MKB : BaseEntity, IModelBuilder
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<Diag> Diags { get; set; } = new HashSet<Diag>();

        public ICollection<Diag> LinkedDiags { get; set; } = new HashSet<Diag>();

        public ICollection<Diagnose> PrimaryDiagnoses { get; set; } = new HashSet<Diagnose>();

        public ICollection<Diagnose> SecondaryDiagnoses { get; set; } = new HashSet<Diagnose>();
    }
}