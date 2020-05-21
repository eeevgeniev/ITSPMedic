using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class InClinicProcedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<InClinicProcedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Patient)
                    .WithMany(p => p.InClinicProcedures)
                    .HasForeignKey(model => model.PatientId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.InClinicProcedures)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasIndex(model => model.PatientBranchId).IsUnique(false);

                b.HasOne(model => model.PatientHealthRegion)
                    .WithMany(hr => hr.InClinicProcedures)
                    .HasForeignKey(model => model.PatientHealthRegionId);

                b.HasIndex(model => model.PatientHealthRegionId).IsUnique(false);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.InClinicProcedures)
                    .HasForeignKey(model => model.SenderId);

                b.HasIndex(model => model.SenderId).IsUnique(false);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstInClinicProcedure)
                    .HasForeignKey<InClinicProcedure>(model => model.FirstMainDiagId);

                b.HasIndex(model => model.FirstMainDiagId).IsUnique(false);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondInClinicProcedure)
                    .HasForeignKey<InClinicProcedure>(model => model.SecondMainDiagId);

                b.HasOne(model => model.CeasedClinicalPath)
                    .WithOne(ccp => ccp.InClinicProcedure)
                    .HasForeignKey<InClinicProcedure>(model => model.CeasedClinicalPathId);

                b.HasIndex(model => model.CeasedClinicalPathId).IsUnique(false);

                b.HasIndex(model => model.HospitalPracticeId).IsUnique(false);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.VisitDocumentUniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.VisitDocumentName).HasMaxLength(100);
            });
        }
    }
}