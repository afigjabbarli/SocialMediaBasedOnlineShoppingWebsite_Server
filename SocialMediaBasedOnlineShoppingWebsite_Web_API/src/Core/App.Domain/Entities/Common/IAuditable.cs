using App.Domain.Enums;
using System;

namespace App.Domain.Entities.Common
{
    public interface IAuditable<TKey> : IEquatable<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey? CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        TKey? ModifiedBy { get; set; }
        DateTime? ModifiedAt { get; set; }
        TKey? StatusModifiedBy { get; set; }
        DateTime? StatusModifiedDate { get; set; }
        Status Status { get; set; }
        TKey? DeletedBy { get; set; }
        DateTime? DeletedAt { get; set; }
        bool IsDeleted { get; set; }
    }
}
