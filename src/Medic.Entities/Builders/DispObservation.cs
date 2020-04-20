using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class DispObservation
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<DispObservation>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.DispObservations)
                    .HasForeignKey(model => model.PatientId);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.DispObservations)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.DispObservations)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasOne(model => model.Sender)
                    .WithMany(s => s.DispObservations)
                    .HasForeignKey(model => model.SenderId);

                b.HasOne(model => model.Doctor)
                    .WithMany(s => s.DoctorDispObservations)
                    .HasForeignKey(model => model.DoctorId);

                b.HasMany(model => model.MDIs)
                    .WithOne(m => m.DispObservation)
                    .HasForeignKey(m => m.DispObservationId);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstDispObservation)
                    .HasForeignKey<DispObservation>(model => model.MainDiagFirstId);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondDispObservation)
                    .HasForeignKey<DispObservation>(model => model.MainDiagSecondId);

                b.Property(model => model.AprCode).HasMaxLength(10);

                b.Property(model => model.Anamnesa).HasMaxLength(4000);

                b.Property(model => model.HState).HasMaxLength(3000);

                b.Property(model => model.Therapy).HasMaxLength(1000);

                b.Property(model => model.Sign).HasMaxLength(5);
            });
        }
    }
}