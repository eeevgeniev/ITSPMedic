using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class CeasedClinicalPath 
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<CeasedClinicalPath>(b =>
            {
                b.HasKey(model => model.Id);
            });
        }
    }
}