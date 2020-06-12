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

                b.HasMany(model => model.AddDiags)
                    .WithOne(ad => ad.ChemotherapyPart)
                    .HasForeignKey(cp => cp.ChemotherapyPartId);

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

                b.Property(model => model.ExpandDiagnose).HasMaxLength(4000);

                b.Property(model => model.TNM).HasMaxLength(100);

                b.Property(model => model.TargetAUC).HasColumnType("decimal(15,4)");

                b.Property(model => model.Staging).HasMaxLength(20);
            });
        }
    }
}