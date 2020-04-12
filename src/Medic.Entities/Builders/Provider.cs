using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class Provider
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<Provider>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}