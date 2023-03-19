using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CategoryModels> Categories { get; set; }
    }
}
