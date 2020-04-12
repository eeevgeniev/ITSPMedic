using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Patient
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Patient>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasIndex(model => model.IdentityNumber).IsUnique(false);
                b.Property(model => model.IdentityNumber).HasMaxLength(50);

                b.HasOne(model => model.Sex)
                    .WithMany(s => s.Patients)
                    .HasForeignKey(model => model.SexId);
            });
        }
    }
}
