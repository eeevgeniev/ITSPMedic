using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class VSD
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<VSD>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.NameVSD).HasMaxLength(250);

                b.Property(model => model.CodeVSD).HasMaxLength(5);

                b.Property(model => model.ACHIcode).HasMaxLength(12);

                b.HasOne(model => model.DispObservation)
                    .WithMany(disp => disp.VSDs)
                    .HasForeignKey(disp => disp.DispObservationId);

                b.HasIndex(model => model.DispObservationId).IsUnique(false);
            });
        }
    }
}
