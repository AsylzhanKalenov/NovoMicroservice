using OrderAPI.Core.DTOs;
using OrderAPI.Core.Entities;
using OrderAPI.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderAPI.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<OrderResponse>> Get();

        Task<SingleOrderResponse> GetById(int Id);

        Task DeleteAsync(SingleOrderResponse singleProduct, CancellationToken cancellationToken = default(CancellationToken));

        Task<Order> AddAsync(CreateOrderRequest entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
