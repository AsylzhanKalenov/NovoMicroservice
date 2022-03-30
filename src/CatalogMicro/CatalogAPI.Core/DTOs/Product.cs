using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Core.DTOs
{
    public class CreateProductRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageFile { get; set; }
        [Required]
        public double Price { get; set; }
    }

    public class UpdateProductRequest : CreateProductRequest
    {
        [Required]
        public int Stock { get; set; }
    }

    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
    public class SingleProductResponse : ProductResponse
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
