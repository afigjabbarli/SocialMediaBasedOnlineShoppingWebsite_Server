using App.Application.Interfaces.Repositories;
using App.Domain.Entities.Common;
using App.Persistence.Contexts.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace App.Persistence.Repositories
{
    public class WriteRepository<T, TKey> : IWriteRepository<T, TKey>
        where T : BaseEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        private readonly WriteDbContext _data_context;

        public WriteRepository(WriteDbContext data_context)
        {
            _data_context = data_context;
        }

        public DbSet<T> Table => _data_context.Set<T>();

        public async Task<bool> AddAsync(T entity, CancellationToken token = default)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                EntityEntry<T> entityEntry = await Table.AddAsync(entity, token);

                return entityEntry.State == EntityState.Added;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(List<T> entities, CancellationToken token = default)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                foreach (var entity in entities)
                {
                    if (!await AddAsync(entity, token))
                        return false;
                }

                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Remove(T entity)
        {
            try
            {
                EntityEntry<T> entityEntry = Table.Remove(entity);
                return entityEntry.State == EntityState.Deleted;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveByIdAsync(TKey key, CancellationToken token = default)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                T entity = await Table.SingleOrDefaultAsync(e => e.Equals(key), token);
                if (entity is not null)
                    return Remove(entity);
                return false;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveRange(List<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (!Remove(entity))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveSingleAsync(Expression<Func<T, bool>> method, CancellationToken token = default)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                T entity = await Table.SingleOrDefaultAsync(method, token);
                if (entity is not null) return Remove(entity);
                return false;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveWhere(Expression<Func<T, bool>> method)
        {
            try
            {
                var query = Table.Where(method);
                return RemoveRange(query.ToList());
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                EntityEntry entry = Table.Update(entity);
                return entry.State == EntityState.Modified;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
