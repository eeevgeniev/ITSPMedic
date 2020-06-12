using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class CeasedClinical 
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<CeasedClinical>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Code).HasMaxLength(20);
            });
        }
    }
}