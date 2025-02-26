using Microsoft.EntityFrameworkCore;
using PostRedisApi.Models;

namespace PostRedisApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
