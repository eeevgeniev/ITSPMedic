using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HistologicalResult
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HistologicalResult>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Note).HasMaxLength(2000);

                b.Property(model => model.Code).HasColumnType("decimal(15,4)");
            });
        }
    }
}
