using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Implant
    /// </summary>
    [Serializable]
    public partial class Implant : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? ProductTypeId { get; set; }

        public ImplantProductType ProductType { get; set; }

        public string TradeName { get; set; }

        public string ReferenceNumber { get; set; }

        public string Manufacturer { get; set; }

        public int? ProviderId { get; set; }

        public Provider Provider { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public string SerialNumber { get; set; }

        public int Stickers { get; set; }

        public string DistributorInvoiceNumber { get; set; }

        public DateTime DistributorInvoiceDate { get; set; }

        public decimal NhifAmount { get; set; }

        public decimal PatientAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public Procedure Procedure { get; set; }

        public int? ClinicProcedureId { get; set; }
        
        public ClinicProcedure ClinicProcedure { get; set; }
    }
}