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
using System.Linq;
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


            if (!this.dbContext.Categories.Any())
            {
                this.dbContext.Categories.AddRange(new List<Category>
                        {
                        new Category() { Name = "Sport" },
                        new Category() { Name = "Computers" },
                        new Category() { Name = "Phones" },
                        new Category() { Name = "Books" },
                        });
                this.dbContext.SaveChanges();
            }
            if (!this.dbContext.Products.Any())
            {
                this.dbContext.Products.AddRange(new List<Product>
                {
                    new Product() { Name = "Gantels", CategoryId = 1, Price = 24000, Stock = 15, Discount = 7, CreatedAt = DateUtil.GetCurrentDate(), UpdatedAt = DateUtil.GetCurrentDate()},
                    new Product() { Name = "Asus N434-54", CategoryId = 2, Price = 24000, Stock = 15, Discount = 7, CreatedAt = DateUtil.GetCurrentDate(), UpdatedAt = DateUtil.GetCurrentDate()},
                    new Product() { Name = "Iphone 7S", CategoryId = 3, Price = 24000, Stock = 15, Discount = 7, CreatedAt = DateUtil.GetCurrentDate(), UpdatedAt = DateUtil.GetCurrentDate()},
                    new Product() { Name = "Xiaomi note10 pro", CategoryId = 3, Price = 24000, Stock = 15, Discount = 7, CreatedAt = DateUtil.GetCurrentDate(), UpdatedAt = DateUtil.GetCurrentDate()},
                    new Product() { Name = "George Orwell '1984'", CategoryId = 4, Price = 24000, Stock = 15, Discount = 7, CreatedAt = DateUtil.GetCurrentDate(), UpdatedAt = DateUtil.GetCurrentDate()},
                    new Product() { Name = "Andrey Kurpaton 'Red pill'", CategoryId = 4, Price = 24000, Stock = 15, Discount = 7, CreatedAt = DateUtil.GetCurrentDate(), UpdatedAt = DateUtil.GetCurrentDate()},
                });
                this.dbContext.SaveChanges();
            }
            
        }
        public async Task<List<ProductResponse>> Get()
        {
            return await dbContext.Products.Select(x => mapper.Map<ProductResponse>(x)).ToListAsync();
        }

        public async Task<SingleProductResponse> GetById(int Id)
        {
            var product = await dbContext.Products.FindAsync(Id);
            if (product != null)
            {
                return mapper.Map<SingleProductResponse>(product);
            }

            throw new NotFoundException();
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

        public Task DeleteAsync(SingleProductResponse entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Product> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
