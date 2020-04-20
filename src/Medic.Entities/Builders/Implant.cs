using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Implant
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Implant>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.ProductType)
                    .WithMany(ipt => ipt.Implants)
                    .HasForeignKey(model => model.ProductTypeId);

                b.HasOne(model => model.Provider)
                    .WithMany(p => p.Implants)
                    .HasForeignKey(model => model.ProviderId);

                b.Property(model => model.TradeName).HasMaxLength(500);

                b.Property(model => model.ReferenceNumber).HasMaxLength(10);

                b.Property(model => model.Manufacturer).HasMaxLength(100);

                b.Property(model => model.Code).HasMaxLength(20);

                b.Property(model => model.SerialNumber).HasMaxLength(50);

                b.Property(model => model.DistributorInvoiceNumber).HasMaxLength(10);
            });
        }
    }
}