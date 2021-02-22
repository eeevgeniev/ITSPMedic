using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Planned
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Planned>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.Plannings)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.Planned)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.Planned)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.Planned)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasMany(model => model.SendDiagnoses)
                    .WithOne(d => d.SendPlanned)
                    .HasForeignKey(d => d.SendPlannedId);

                b.HasMany(model => model.Diagnoses)
                    .WithOne(d => d.Planned)
                    .HasForeignKey(d => d.PlannedId);

                b.HasIndex(model => model.CPFileId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.UniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.SendClinicalPath).HasMaxLength(10);

                b.Property(model => model.SendAPr).HasMaxLength(10);

                b.Property(model => model.ClinicalPath).HasMaxLength(10);

                b.Property(model => model.InAPr).HasMaxLength(10);
            });
        }
    }
}