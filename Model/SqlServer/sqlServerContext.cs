using Microsoft.EntityFrameworkCore;

namespace BC_Veterinaria.Model.SqlServer
{
    public class sqlServerContext: DbContext
    {
        public sqlServerContext(DbContextOptions<sqlServerContext> options)
            : base(options)
        {
        }
        
        public DbSet<dog> DOGS { get; set; } = null!;
    }
}
