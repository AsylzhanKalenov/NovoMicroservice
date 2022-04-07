using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using OrderAPI.Core.DTOs;
using OrderAPI.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrderAPI.Consumers
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper mapper;
        private readonly ILogger<BasketCheckoutConsumer> logger;
        private readonly IOrderRepository orderRepository;

        public BasketCheckoutConsumer(IMapper mapper, ILogger<BasketCheckoutConsumer> logger, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var request = mapper.Map<CreateOrderRequest>(context.Message);
            request.CustomerId = Guid.NewGuid();
            request.StatusId = 1;
            var order = await orderRepository.AddAsync(request);
            logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", order);
        }
    }
}
