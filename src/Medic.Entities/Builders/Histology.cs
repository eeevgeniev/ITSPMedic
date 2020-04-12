using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Histology
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Histology>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}
