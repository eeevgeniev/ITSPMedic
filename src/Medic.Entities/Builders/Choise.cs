using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Choise
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Choise>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Text).HasMaxLength(1000);
            });
        }
    }
}