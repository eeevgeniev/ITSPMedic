using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ClinicProcedure
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ClinicProcedure>(b =>
            {
                b.HasKey(model => model.Id);

                b.HasOne(model => model.InClinicProcedure)
                    .WithMany(ip => ip.Procedures)
                    .HasForeignKey(model => model.InClinicProcedureId);

                b.HasIndex(model => model.InClinicProcedureId).IsUnique(false);

                b.HasIndex(model => model.PathProcedureId).IsUnique(false);

                b.Property(model => model.ProcedureName).HasMaxLength(300);

                b.Property(model => model.ACHIcode).HasMaxLength(12);

                b.Property(model => model.ProcedureCode).HasColumnType("decimal(15,4)");
            });
        }
    }
}