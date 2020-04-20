using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class CeasedClinicalPath 
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<CeasedClinicalPath>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Code).HasMaxLength(5);

                b.Property(model => model.IZMedicalWard).HasMaxLength(6);

                b.Property(model => model.IZYearMedicalWard).HasMaxLength(4);
            });
        }
    }
}