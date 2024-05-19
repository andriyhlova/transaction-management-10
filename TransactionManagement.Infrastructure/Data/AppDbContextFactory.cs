using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TransactionManagement.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost; Database=TransactionManagement; Username=postgres; Password=tMzR3mry");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
