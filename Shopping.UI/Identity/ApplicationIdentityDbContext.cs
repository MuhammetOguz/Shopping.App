using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shopping.UI.Identity
{
    public class ApplicationIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext>options):base(options)
        {
            
        }
    }
}
