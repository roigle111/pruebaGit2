using Microsoft.EntityFrameworkCore;

namespace PersistenceDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
    }
}
