using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class APr05
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<APr05>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Histology)
                    .WithOne(h => h.APr05)
                    .HasForeignKey<APr05>(model => model.HistologyId);

                b.HasIndex(model => model.HistologyId).IsUnique(false);

                b.HasOne(model => model.ClinicChemotherapyPart)
                    .WithMany(ccp => ccp.APr05s)
                    .HasForeignKey(model => model.ClinicChemotherapyPartId);

                b.HasIndex(model => model.ClinicChemotherapyPartId).IsUnique(false);

                b.HasOne(model => model.ClinicHematologyPart)
                    .WithMany(chp => chp.APr05s)
                    .HasForeignKey(model => model.ClinicHematologyPartId);

                b.HasIndex(model => model.ClinicHematologyPartId).IsUnique(false);

                b.Property(model => model.Staging).HasMaxLength(20);
                b.Property(model => model.Imuno).HasMaxLength(3000);
                b.Property(model => model.Genetic).HasMaxLength(2000);
                b.Property(model => model.Sign).HasMaxLength(50);
            });
        }
    }
}
