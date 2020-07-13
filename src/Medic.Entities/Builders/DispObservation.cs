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

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.DispObservations)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.DispObservations)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Doctor)
                    .WithMany(s => s.DoctorDispObservations)
                    .HasForeignKey(model => model.DoctorId);

                b.HasIndex(model => model.DoctorId).IsUnique(false);

                b.HasMany(model => model.MDIs)
                    .WithOne(m => m.DispObservation)
                    .HasForeignKey(m => m.DispObservationId);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstDispObservation)
                    .HasForeignKey<DispObservation>(model => model.MainDiagFirstId);

                b.HasIndex(model => model.MainDiagFirstId).IsUnique(false);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondDispObservation)
                    .HasForeignKey<DispObservation>(model => model.MainDiagSecondId);

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.HasIndex(model => model.MainDiagSecondId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.AprCode).HasMaxLength(10);

                b.Property(model => model.HState).HasMaxLength(3000);

                b.Property(model => model.Therapy).HasMaxLength(1000);

                b.Property(model => model.FirstCodeSpecConsult).HasMaxLength(5);

                b.Property(model => model.SecondCodeSpecConsult).HasMaxLength(5);
            });
        }
    }
}