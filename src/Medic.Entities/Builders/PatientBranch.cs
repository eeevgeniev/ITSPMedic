using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class PatientBranch
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<PatientBranch>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.HealthRegion)
                    .WithMany(hr => hr.PatientBranches)
                    .HasForeignKey(model => model.HealthRegionId);

                b.HasIndex(model => model.HealthRegionId).IsUnique(false);
            });
        }
    }
}