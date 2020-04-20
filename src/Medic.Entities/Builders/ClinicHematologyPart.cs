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

                b.HasMany(model => model.Decisions)
                    .WithOne(e => e.ClinicHematologyPart)
                    .HasForeignKey(e => e.ClinicHematologyPartId);

                b.HasOne(model => model.Evaluation)
                    .WithOne(e => e.ClinicHematologyPartDecision)
                    .HasForeignKey<ClinicHematologyPart>(model => model.EvalutionId);

                b.Property(model => model.StageHemo).HasMaxLength(10);
            });
        }
    }
}