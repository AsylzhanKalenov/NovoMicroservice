using AutoMapper;
using EventBus.Messages.Events;
using OrderAPI.Core.DTOs;
using OrderAPI.Core.Entities;

namespace OrderAPI.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateOrderRequest, Order>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );

            CreateMap<BasketCheckoutEvent, CreateOrderRequest>();

            CreateMap<Order, OrderResponse>();
        }
    }
}
