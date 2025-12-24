using Microsoft.EntityFrameworkCore;
using MySecondDotNetApi.Models;

namespace MySecondDotNetApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Add your DbSets here
        // Example: public DbSet<YourModel> YourModels { get; set; }
    }
}
