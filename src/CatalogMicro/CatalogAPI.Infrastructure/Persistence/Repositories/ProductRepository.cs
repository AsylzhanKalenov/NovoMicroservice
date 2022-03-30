using AutoMapper;
using CatalogAPI.Core.DTOs;
using CatalogAPI.Core.Entities;
using CatalogAPI.Core.Exceptions;
using CatalogAPI.Core.Interfaces;
using CatalogAPI.Core.Utils;
using CatalogAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogAPI.Infrastructure.Persistence.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public ProductRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Product> AddAsync(CreateProductRequest entity, CancellationToken cancellationToken = default)
        {
            var product = this.mapper.Map<Product>(entity);
            product.Stock = 0;
            product.CreatedAt = product.UpdatedAt = DateUtil.GetCurrentDate();

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public Task DeleteAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Product> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> Get()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int Id)
        {
            var product = await dbContext.Products.FindAsync(Id);
            if (product != null)
            {
                return product;
            }

            throw new NotFoundException();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
