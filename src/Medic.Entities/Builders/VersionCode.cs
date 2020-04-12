using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class VersionCode
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<VersionCode>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}
