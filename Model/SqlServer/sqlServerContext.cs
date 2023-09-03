using Microsoft.EntityFrameworkCore;

namespace BC_Veterinaria.Model.SqlServer
{
    public class sqlServerContext: DbContext
    {
        public sqlServerContext(DbContextOptions<sqlServerContext> options)
            : base(options)
        {
        }
        
        public DbSet<Dog> DOGS { get; set; } = null!;
        public DbSet<User> USERS { get; set; } = null!;
    }
}

