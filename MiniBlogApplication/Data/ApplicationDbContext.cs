using Microsoft.EntityFrameworkCore;
using MiniBlogApplication.Models.Entities;
namespace MiniBlogApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
            public DbSet<Post> Posts { get; set; }
        
    }
}
