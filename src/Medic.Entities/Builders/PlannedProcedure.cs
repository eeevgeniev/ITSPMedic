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

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.PlannedProcedures)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHRegion)
                    .WithMany(hr => hr.PlannedProcedures)
                    .HasForeignKey(model => model.PatientHRegionId);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.PlannedProcedures)
                    .HasForeignKey(model => model.SenderId);

                b.HasOne(model => model.SendDiagnose)
                    .WithOne(d => d.SendPlannedProcedure)
                    .HasForeignKey<PlannedProcedure>(model => model.SendDiagnoseId);

                b.HasOne(model => model.Diagnose)
                    .WithOne(d => d.PlannedProcedure)
                    .HasForeignKey<PlannedProcedure>(model => model.DiagnoseId);
            });
        }
    }
}