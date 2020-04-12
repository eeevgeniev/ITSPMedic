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
            });
        }
    }
}