using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Contexts.Read
{
    public class ReadDbContext : DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }
    }
}
