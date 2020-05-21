using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Evaluation
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Evaluation>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasMany(model => model.Choices)
                    .WithOne(c => c.Evaluation)
                    .HasForeignKey(c => c.EvaluationId);

                b.HasIndex(model => model.ClinicChemotherapyPartId).IsUnique(false);

                b.HasIndex(model => model.ClinicHematologyPartId).IsUnique(false);
            });
        }
    }
}
