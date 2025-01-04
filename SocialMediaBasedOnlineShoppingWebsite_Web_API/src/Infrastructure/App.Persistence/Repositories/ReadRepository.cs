using App.Application.Interfaces.Repositories;
using App.Domain.Entities.Common;
using App.Persistence.Contexts.Read;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Persistence.Repositories
{
    public class ReadRepository<T, TKey> : IReadRepository<T, TKey>
        where T : BaseEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        private readonly ReadDbContext _data_context;
        public ReadRepository(ReadDbContext data_context)
        {
            _data_context = data_context;
        }
        public DbSet<T> Table => _data_context.Set<T>();

        public IQueryable<T> Get(bool isTracking = true)
        {
            var query = Table.AsQueryable();
            if (!isTracking) query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool isTracking = true)
        {
            var query = Table.Where(method);
            if (!isTracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(TKey key, bool isTracking = true)
        {
            var query = Table.AsQueryable();
            if (!isTracking) query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(q => q.Equals(key));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool isTracking = true)
        {
            var query = Table.AsQueryable();
            if (!isTracking) query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(method);
        }

    }
}
