using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ClinicChemotherapyPart
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ClinicChemotherapyPart>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Decision)
                    .WithOne(e => e.ClinicChemotherapyPartDecision)
                    .HasForeignKey<ClinicChemotherapyPart>(model => model.DecisionId);

                b.HasIndex(model => model.DecisionId).IsUnique(false);

                b.HasOne(model => model.Evaluation)
                    .WithOne(e => e.ClinicChemotherapyPart)
                    .HasForeignKey<ClinicChemotherapyPart>(model => model.EvalutionId);

                b.HasIndex(model => model.EvalutionId).IsUnique(false);

                b.Property(model => model.TNM).HasMaxLength(100);
            });
        }
    }
}