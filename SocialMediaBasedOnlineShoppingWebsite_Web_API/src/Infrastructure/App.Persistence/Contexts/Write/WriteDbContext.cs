using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Contexts.Write
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }
    }
}
