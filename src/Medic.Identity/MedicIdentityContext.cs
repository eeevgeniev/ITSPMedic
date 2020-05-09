using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medic.Identity
{
    public class MedicIdentityContext : IdentityDbContext
    {
        public MedicIdentityContext(DbContextOptions<MedicIdentityContext> options)
            : base (options)
        {

        }
    }
}