using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class ImplantProductType
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<ImplantProductType>(b =>
            {
                b.HasKey(model => model.Id);

                b.Property(model => model.Name).HasMaxLength(100);
            });
        }
    }
}