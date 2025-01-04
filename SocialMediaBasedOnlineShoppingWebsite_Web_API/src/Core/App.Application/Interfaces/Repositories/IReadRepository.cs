using App.Domain.Entities.Common;
using System.Linq.Expressions;

namespace App.Application.Interfaces.Repositories
{
    public interface IReadRepository<T, TKey> : IRepository<T, TKey>
        where T : BaseEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        IQueryable<T> Get(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool isTracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool isTracking = true);
        Task<T> GetByIdAsync(TKey key, bool isTracking = true);
    }
}
