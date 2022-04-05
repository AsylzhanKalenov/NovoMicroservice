using CatalogAPI.Core.DTOs;
using CatalogAPI.Core.Entities;
using CatalogAPI.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogAPI.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<ProductResponse>> Get();

        Task<SingleProductResponse> GetById(int Id);

        Task DeleteAsync(SingleProductResponse singleProduct, CancellationToken cancellationToken = default(CancellationToken));
        
        Task<Product> AddAsync(CreateProductRequest entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
