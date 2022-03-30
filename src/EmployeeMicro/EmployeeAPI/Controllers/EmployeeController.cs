using EmployeeAPI.Core.Entities;
using EmployeeAPI.Core.Exceptions;
using EmployeeAPI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <response code="200">Returns the products</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<IEnumerable<Employee>>))]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await repository.Get();
        }

        /// <summary>
        /// Get a Employee by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <response code="200">Returns the existing product</response>
        /// <response code="404">If the product doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            try
            {
                var employee = await repository.GetById(id);
                return Ok(employee);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
