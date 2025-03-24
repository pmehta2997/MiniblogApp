using AssignmentProjectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentProjectMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; }
    }
}
