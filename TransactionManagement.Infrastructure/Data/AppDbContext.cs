using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransactionManagement.Core.Entities;

namespace TransactionManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
