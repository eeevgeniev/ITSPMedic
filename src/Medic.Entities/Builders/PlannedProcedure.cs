using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class PlannedProcedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<PlannedProcedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.PlannedProcedures)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.PlannedProcedures)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.PlannedProcedures)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasIndex(model => model.PatientHRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.PlannedProcedures)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasOne(model => model.SendDiagnose)
                    .WithOne(d => d.SendPlannedProcedure)
                    .HasForeignKey<PlannedProcedure>(model => model.SendDiagnoseId);

                b.HasIndex(model => model.SendDiagnoseId).IsUnique(false);

                b.HasOne(model => model.Diagnose)
                    .WithOne(d => d.PlannedProcedure)
                    .HasForeignKey<PlannedProcedure>(model => model.DiagnoseId);

                b.HasIndex(model => model.DiagnoseId).IsUnique(false);

                b.HasIndex(model => model.CPFileId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.UniqueIdentifier).HasMaxLength(12);
            });
        }
    }
}