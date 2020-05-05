﻿using Microsoft.EntityFrameworkCore;

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

                b.HasOne(model => model.PatientBranch)
                    .WithMany(pb => pb.InClinicProcedures)
                    .HasForeignKey(model => model.PatientBranchId);

                b.HasOne(model => model.PatientHealthRegion)
                    .WithMany(hr => hr.InClinicProcedures)
                    .HasForeignKey(model => model.PatientHealthRegionId);

                b.HasOne(model => model.Sender)
                    .WithMany(hp => hp.InClinicProcedures)
                    .HasForeignKey(model => model.SenderId);

                b.HasOne(model => model.FirstMainDiag)
                    .WithOne(d => d.FirstInClinicProcedure)
                    .HasForeignKey<InClinicProcedure>(model => model.FirstMainDiagId);

                b.HasOne(model => model.SecondMainDiag)
                    .WithOne(d => d.SecondInClinicProcedure)
                    .HasForeignKey<InClinicProcedure>(model => model.SecondMainDiagId);

                b.HasOne(model => model.CeasedClinicalPath)
                    .WithOne(ccp => ccp.InClinicProcedure)
                    .HasForeignKey<InClinicProcedure>(model => model.CeasedClinicalPathId);

                b.HasIndex(model => model.PatientId).IsUnique(false);

                b.Property(model => model.VisitDocumentUniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.VisitDocumentName).HasMaxLength(100);
            });
        }
    }
}