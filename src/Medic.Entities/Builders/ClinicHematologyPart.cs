using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ClinicHematologyPart
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ClinicHematologyPart>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Decision)
                    .WithOne(e => e.ClinicHematologyPartDecision)
                    .HasForeignKey<ClinicHematologyPart>(model => model.DecisionId);

                b.HasIndex(model => model.DecisionId).IsUnique(false);

                b.HasOne(model => model.Evaluation)
                    .WithOne(e => e.ClinicHematologyPart)
                    .HasForeignKey<ClinicHematologyPart>(model => model.EvalutionId);

                b.HasIndex(model => model.EvalutionId).IsUnique(false);

                b.Property(model => model.StageHemo).HasMaxLength(10);
            });
        }
    }
}