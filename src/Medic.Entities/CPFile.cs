using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> CPFile
    /// </summary>
    [Serializable]
    public partial class CPFile : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PracticeId { get; set; }

        public Practice Practice { get; set; }

        public int? FileTypeId { get; set; }

        public FileType FileType { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<PlannedProcedure> PlannedProcedures { get; set; }

        public ICollection<In> Ins { get; set; } = new HashSet<In>();

        public ICollection<Out> Outs { get; set; } = new HashSet<Out>();

        public ICollection<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; } = new HashSet<ProtocolDrugTherapy>();

        public List<PatientTransfer> PatientTransfers { get; set; }
    }
}