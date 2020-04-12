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

                b.HasMany(model => model.Decisions)
                    .WithOne(e => e.ClinicChemotherapyPart)
                    .HasForeignKey(e => e.ClinicChemotherapyPartId);

                b.HasOne(model => model.Evaluation)
                    .WithOne(e => e.ClinicChemotherapyPartDecision)
                    .HasForeignKey<ClinicChemotherapyPart>(model => model.EvalutionId);
            });
        }
    }
}