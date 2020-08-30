using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medic.Identity
{
    public class MedicIdentityContext : IdentityDbContext
    {
        private const string DbScheme = "idt";
        
        public MedicIdentityContext(DbContextOptions<MedicIdentityContext> options)
            : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(DbScheme);
            
            base.OnModelCreating(builder);
        }
    }
}