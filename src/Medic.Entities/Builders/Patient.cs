using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Patient
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Patient>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.Sex)
                    .WithMany(s => s.Patients)
                    .HasForeignKey(model => model.SexId);

                b.HasIndex(model => model.SexId).IsUnique(false);

                b.HasIndex(model => model.IdentityNumber).IsUnique(false);

                b.Property(model => model.IdentityNumber).HasMaxLength(50);

                b.Property(model => model.CountryCode).HasMaxLength(5);

                b.Property(model => model.InstitutionId).HasMaxLength(100);

                b.Property(model => model.InstitutionName).HasMaxLength(100);

                b.Property(model => model.CertificateType).HasMaxLength(50);

                b.Property(model => model.EhicC).HasMaxLength(50);

                b.Property(model => model.PersonalIdNumber).HasMaxLength(50);

                b.Property(model => model.Notes).HasMaxLength(200);

                b.Property(model => model.FirstName).HasMaxLength(50);

                b.Property(model => model.SecondName).HasMaxLength(50);

                b.Property(model => model.LastName).HasMaxLength(50);

                b.Property(model => model.Address).HasMaxLength(200);
            });
        }
    }
}
