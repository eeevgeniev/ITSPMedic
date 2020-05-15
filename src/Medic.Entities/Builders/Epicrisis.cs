using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Epicrisis
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Epicrisis>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasMany(model => model.HealthcarePractitionerEpicrisises)
                    .WithOne(hpe => hpe.Epicrisis)
                    .HasForeignKey(hpe => hpe.EpicrisisId);

                b.Property(model => model.History).HasMaxLength(5000);

                b.Property(model => model.FairCondition).HasMaxLength(5000);

                b.Property(model => model.ClinicalExaminations).HasMaxLength(5000);

                b.Property(model => model.Consultations).HasMaxLength(5000);

                b.Property(model => model.Regimen).HasMaxLength(5000);

                b.Property(model => model.DiseaseCourse).HasMaxLength(5000);

                b.Property(model => model.Complications).HasMaxLength(5000);

                b.Property(model => model.SampleProtocol).HasMaxLength(5000);

                b.Property(model => model.PostoperativeStatus).HasMaxLength(5000);

                b.Property(model => model.DischargeStatus).HasMaxLength(5000);

                b.Property(model => model.Recommendations).HasMaxLength(5000);

                b.Property(model => model.CheckupAfterDischarge).HasMaxLength(5000);

                b.Property(model => model.GPRecommendations).HasMaxLength(5000);

                b.Property(model => model.OtherDocuments).HasMaxLength(5000);
            });
        }
    }
}
