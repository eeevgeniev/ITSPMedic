using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> APr05
    /// </summary>
    [Serializable]
    public partial class APr05 : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime DiagnoseDate { get; set; }

        public int HistologyId { get; set; }

        public Histology Histology { get; set; }

        public string Staging { get; set; }

        public string Imuno { get; set; }

        public string Genetic { get; set; }

        public int? ClinicChemotherapyPartId { get; set; }

        public ClinicChemotherapyPart ClinicChemotherapyPart { get; set; }

        public int? ClinicHematologyPartId { get; set; }

        public ClinicHematologyPart ClinicHematologyPart { get; set; }

        public string Sign { get; set; }

        public int NZOKPay { get; set; }

        public CommissionApr CommissionApr { get; set; }
    }
}