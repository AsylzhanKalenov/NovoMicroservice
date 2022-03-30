using CatalogAPI.SharedKernel;
using System;

namespace CatalogAPI.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int HeadCatId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
