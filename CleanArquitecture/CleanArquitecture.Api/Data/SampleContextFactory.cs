using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using CleanArquitecture.Infrastructure.Data;

namespace CleanArquitecture.Api.Data
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("Conexion");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("CleanArquitecture.Infrastructure"));

            return new AppDbContext(builder.Options);
        }
    }
}
