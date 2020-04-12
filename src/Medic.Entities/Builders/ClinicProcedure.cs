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
            });
        }
    }
}