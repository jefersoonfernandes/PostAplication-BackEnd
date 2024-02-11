using Microsoft.EntityFrameworkCore;
using PostAplication.Models;

namespace PostAplication.Data
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }
    }
}
