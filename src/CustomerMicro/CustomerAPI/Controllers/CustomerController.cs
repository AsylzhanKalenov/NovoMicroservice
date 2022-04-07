using CustomerAPI.Core.Entities;
using CustomerAPI.Core.Exceptions;
using CustomerAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <response code="200">Returns the products</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IEnumerable<Customer>>))]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await repository.Get();
        }

        /// <summary>
        /// Get a Customer by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <response code="200">Returns the existing product</response>
        /// <response code="404">If the product doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            try
            {
                var Customer = await repository.GetById(id);
                return Ok(Customer);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
