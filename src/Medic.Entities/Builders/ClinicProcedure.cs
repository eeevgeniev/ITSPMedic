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

                b.Property(model => model.ProcedureName).HasMaxLength(200);

                b.Property(model => model.ACHIcode).HasMaxLength(12);

                b.Property(model => model.ProcedureCode).HasColumnType("decimal(15,4)");
            });
        }
    }
}