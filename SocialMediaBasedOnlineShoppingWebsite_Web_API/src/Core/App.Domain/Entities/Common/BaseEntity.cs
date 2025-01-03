using App.Domain.Enums;
using System;

namespace App.Domain.Entities.Common
{
    public abstract class BaseEntity<TKey> : IAuditable<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public TKey? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public TKey? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public TKey? StatusModifiedBy { get; set; }
        public DateTime? StatusModifiedDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public TKey? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Equals(TKey other)
        {
            return Id.Equals(other);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is BaseEntity<TKey> entity)
            {
                return Equals(entity.Id);
            }

            return false;
        }
    }
}
