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
                b.Property(model => model.Code).HasMaxLength(200);
            });
        }
    }
}