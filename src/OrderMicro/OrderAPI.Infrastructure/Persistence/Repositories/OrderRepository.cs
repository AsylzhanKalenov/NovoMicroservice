using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Core.DTOs;
using OrderAPI.Core.Entities;
using OrderAPI.Core.Exceptions;
using OrderAPI.Core.Interfaces;
using OrderAPI.Core.Utils;
using OrderAPI.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public OrderRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<OrderResponse>> Get()
        {
            return await dbContext.Orders.Select(x => mapper.Map<OrderResponse>(x)).ToListAsync();
        }

        public async Task<SingleOrderResponse> GetById(int Id)
        {
            var Order = await dbContext.Orders.FindAsync(Id);
            if (Order != null)
            {
                return mapper.Map<SingleOrderResponse>(Order);
            }

            throw new NotFoundException();
        }

        public async Task<Order> AddAsync(CreateOrderRequest entity, CancellationToken cancellationToken = default)
        {
            var Order = this.mapper.Map<Order>(entity);
            Order.CreatedAt = Order.UpdatedAt = DateUtil.GetCurrentDate();

            dbContext.Orders.Add(Order);
            await dbContext.SaveChangesAsync();
            return Order;
        }

        public Task DeleteAsync(SingleOrderResponse entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Order> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
