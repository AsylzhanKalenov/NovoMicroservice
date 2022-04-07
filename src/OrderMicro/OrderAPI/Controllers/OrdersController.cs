using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Core.DTOs;
using OrderAPI.Core.Entities;
using OrderAPI.Core.Exceptions;
using OrderAPI.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <response code="200">Returns the Orders</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
        {
            return await orderRepository.Get();
        }

        /// <summary>
        /// Get a Order by id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <response code="200">Returns the existing Order</response>
        /// <response code="404">If the Order doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SingleOrderResponse>> GetById(int id)
        {
            try
            {
                var Order = await orderRepository.GetById(id);
                return Order;
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create a Order
        /// </summary>
        /// <param name="request">Order data</param>
        /// <response code="201">Returns the created Order</response>
        /// <response code="400">If the data doesn't pass the validations</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> Create(CreateOrderRequest request)
        {
            var Order = await orderRepository.AddAsync(request);
            return StatusCode(201, Order);
        }
    }
}
