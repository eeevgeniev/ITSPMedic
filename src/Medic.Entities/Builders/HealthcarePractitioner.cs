﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HealthcarePractitioner
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HealthcarePractitioner>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasMany(model => model.ProtocolDrugTherapies)
                    .WithOne(pdthp => pdthp.HealthcarePractitioner)
                    .HasForeignKey(pdthp => pdthp.HealthcarePractitionerId);

                b.HasOne(model => model.HealthRegion)
                    .WithMany(hr => hr.HealthcarePractitioners)
                    .HasForeignKey(model => model.HealthRegionId);

                b.HasIndex(model => model.HealthRegionId).IsUnique(false);

                b.HasOne(model => model.SenderType)
                    .WithMany(st => st.HealthcarePractitioners)
                    .HasForeignKey(model => model.SenderTypeId);

                b.HasIndex(model => model.SenderTypeId).IsUnique(false);

                b.HasOne(model => model.Speciality)
                    .WithMany(s => s.HealthcarePractitioners)
                    .HasForeignKey(model => model.SpecialityId);

                b.HasIndex(model => model.SpecialityId).IsUnique(false);

                b.HasOne(model => model.Practice)
                    .WithMany(p => p.HealthcarePractitioners)
                    .HasForeignKey(model => model.PracticeId);

                b.HasIndex(model => model.PracticeId).IsUnique(false);

                b.HasMany(model => model.CommissionAprsMembers)
                    .WithOne(cahp => cahp.HealthcarePractitioner)
                    .HasForeignKey(cahp => cahp.HealthcarePractitionerId);

                b.Property(model => model.UniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.DeputyUniqueIdentifier).HasMaxLength(12);

                b.Property(model => model.Name).HasMaxLength(150);

                b.Property(model => model.NZOKCode).HasMaxLength(12);

                b.Property(model => model.UINSubst).HasMaxLength(12);
            });
        }
    }
}