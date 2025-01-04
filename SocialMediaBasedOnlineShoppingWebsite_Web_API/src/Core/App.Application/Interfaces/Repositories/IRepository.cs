using App.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Repositories
{
    public interface IRepository<T, TKey>
        where T : BaseEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
       DbSet<T> Table {  get; }
    }
}
