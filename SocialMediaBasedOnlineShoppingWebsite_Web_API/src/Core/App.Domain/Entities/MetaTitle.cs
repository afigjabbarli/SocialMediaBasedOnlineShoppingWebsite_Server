using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class MetaTitle : BaseEntity<Guid>
    {
        public required string Name { get; set; } = string.Empty;
    }
}
