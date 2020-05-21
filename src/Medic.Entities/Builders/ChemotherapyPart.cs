using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ChemotherapyPart
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ChemotherapyPart>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.AddDiag)
                    .WithOne(ad => ad.ChemotherapyPart)
                    .HasForeignKey<ChemotherapyPart>(model => model.AddDiagId);

                b.HasIndex(model => model.AddDiagId).IsUnique(false);

                b.HasOne(model => model.Histology)
                    .WithMany(h => h.ChemotherapyParts)
                    .HasForeignKey(model => model.HistologyId);

                b.HasIndex(model => model.HistologyId).IsUnique(false);

                b.HasOne(model => model.Evaluation)
                    .WithOne(e => e.ChemotherapyPart)
                    .HasForeignKey<ChemotherapyPart>(model => model.EvaluationId);

                b.HasIndex(model => model.EvaluationId).IsUnique(false);

                b.HasMany(model => model.GenMarkers)
                    .WithOne(gm => gm.ChemotherapyPart)
                    .HasForeignKey(gm => gm.ChemotherapyPartId);

                b.Property(model => model.ExpandDiagnose).HasMaxLength(300);

                b.Property(model => model.TNM).HasMaxLength(100);

                b.Property(model => model.Staging).HasMaxLength(5);
            });
        }
    }
}