using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required int DisplayOrder { get; set; }
    }
}
