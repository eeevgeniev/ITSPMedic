using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class PractitionerType
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<PractitionerType>(b =>
            {
                b.HasKey(model => model.Id);
                b.HasIndex(model => model.Name).IsUnique();
            });
        }
    }
}