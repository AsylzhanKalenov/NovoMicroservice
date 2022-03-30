using CatalogAPI.Core.DTOs;
using CatalogAPI.Core.Entities;
using CatalogAPI.Core.Exceptions;
using CatalogAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <response code="200">Returns the products</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await productRepository.Get();
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <response code="200">Returns the existing product</response>
        /// <response code="404">If the product doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var product = await productRepository.GetById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="request">Product data</param>
        /// <response code="201">Returns the created product</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Create(CreateProductRequest request)
        {
            var product = await productRepository.AddAsync(request);
            return StatusCode(201, product);
        }
    }
}
