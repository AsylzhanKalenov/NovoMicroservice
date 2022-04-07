using AutoMapper;
using CustomerAPI.Core.DTOs;
using CustomerAPI.Core.Entities;

namespace CustomerAPI.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>()
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
        }
    }
}
