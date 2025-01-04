using App.Domain.Entities;
using App.Persistence.Configurations.CategoryConfig;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
