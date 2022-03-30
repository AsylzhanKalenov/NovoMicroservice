using CatalogAPI.Core.DTOs;
using CatalogAPI.Core.Entities;
using CatalogAPI.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogAPI.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> AddAsync(CreateProductRequest entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
