﻿using Bigon.Domain.Models.Stables;
using Bigon.Infrastructure.Concrates;

namespace Bigon.Domain.Models.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
