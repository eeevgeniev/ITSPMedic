using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class In
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<In>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.Ins)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.Ins)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.Ins)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.Ins)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasOne(model => model.SendDiagnose)
                    .WithOne(d => d.In)
                    .HasForeignKey<In>(model => model.SendDiagnoseId);

                b.HasIndex(model => model.SendDiagnoseId).IsUnique(false);

                b.HasMany(model => model.Diagnoses)
                    .WithOne(d => d.MainIn)
                    .HasForeignKey(d => d.MainInId);

                b.HasIndex(model => model.CPFileId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.SendClinicalPath).HasMaxLength(10);

                b.Property(model => model.UniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.ClinicalPath).HasMaxLength(10);

                b.Property(model => model.InMedicalWard).HasColumnType("decimal(15,4)");
            });
        }
    }
}
