using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class DoneProcedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<DoneProcedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasIndex(model => model.PathProcedureId).IsUnique(false);

                b.HasIndex(model => model.DoctorId).IsUnique(false);

                b.HasOne(model => model.Doctor)
                    .WithMany(hp => hp.DoneProcedures)
                    .HasForeignKey(model => model.DoctorId);
            });
        }
    }
}
