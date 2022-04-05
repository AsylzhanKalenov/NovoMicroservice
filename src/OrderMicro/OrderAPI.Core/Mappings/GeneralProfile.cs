using AutoMapper;
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

            CreateMap<Order, OrderResponse>();
        }
    }
}
