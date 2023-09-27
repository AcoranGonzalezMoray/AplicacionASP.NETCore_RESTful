using CleanArquitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace CleanArquitecture.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
