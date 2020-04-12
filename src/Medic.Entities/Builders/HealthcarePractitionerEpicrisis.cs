using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HealthcarePractitionerEpicrisis
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HealthcarePractitionerEpicrisis>(b =>
            {
                b.HasKey(model => new { model.HealthcarePractitionerId, model.EpicrisisId });
            });
        }
    }
}