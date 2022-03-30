using CatalogAPI.SharedKernel;
using CatalogAPI.SharedKernel.Interfaces;
using System;

namespace CatalogAPI.Core.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Category Category { get; set; }
    }
}
