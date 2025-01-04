using App.Domain.Entities.Common;
using System.Linq.Expressions;

namespace App.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T, TKey> : IRepository<T, TKey>
        where T : BaseEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        Task<bool> AddAsync(T entity, CancellationToken token = default);
        Task<bool> AddRangeAsync(List<T> entities, CancellationToken token = default);
        bool Remove(T entity);
        bool RemoveRange(List<T> entities);
        bool RemoveWhere(Expression<Func<T, bool>> method);
        Task<bool> RemoveSingleAsync(Expression<Func<T, bool>> method, CancellationToken token = default);
        Task<bool> RemoveByIdAsync(TKey key, CancellationToken token = default);
        bool Update(T entity);
    }
}
