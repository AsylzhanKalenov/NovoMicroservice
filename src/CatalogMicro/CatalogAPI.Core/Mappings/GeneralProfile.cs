using AutoMapper;
using CatalogAPI.Core.DTOs;
using CatalogAPI.Core.Entities;

namespace CatalogAPI.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductRequest, Product>()
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

            CreateMap<Product, ProductResponse>();

            CreateMap<Product, SingleProductResponse>();
        }
    }
}
