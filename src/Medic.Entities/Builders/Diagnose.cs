using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Diagnose
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Diagnose>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Primary)
                    .WithMany(mkb => mkb.PrimaryDiagnoses)
                    .HasForeignKey(model => model.PrimaryCode);

                b.HasIndex(model => model.PrimaryCode).IsUnique(false);

                b.HasOne(model => model.Secondary)
                    .WithMany(mkb => mkb.SecondaryDiagnoses)
                    .HasForeignKey(model => model.SecondaryCode);

                b.HasIndex(model => model.MainInId).IsUnique(false);

                b.HasIndex(model => model.OutId).IsUnique(false);

                b.HasIndex(model => model.OutOutId).IsUnique(false);

                b.HasIndex(model => model.SecondaryCode).IsUnique(false);

                b.Property(model => model.PrimaryCode).HasMaxLength(10);

                b.Property(model => model.SecondaryCode).HasMaxLength(10);
            });
        }
    }
}