using App.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class MetaDescription : BaseEntity<Guid>
    {
        public required string Description { get; set; } = string.Empty;   
    }
}
