using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace App.Persistence.Contexts.Read
{
    public class ReadDbContext : BaseDbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }
    }
}
