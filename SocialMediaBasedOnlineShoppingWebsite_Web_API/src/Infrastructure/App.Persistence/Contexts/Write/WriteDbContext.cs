using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Contexts.Write
{
    public class WriteDbContext : BaseDbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }
    }
}
