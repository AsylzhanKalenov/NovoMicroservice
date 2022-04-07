using AutoMapper;
using CustomerAPI.Core.DTOs;
using CustomerAPI.Core.Entities;
using CustomerAPI.Core.Interfaces;
using CustomerAPI.Core.Utils;
using CustomerAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerAPI.Infrastructure.Persistence.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public CustomerRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Customer> AddAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var employee = this.mapper.Map<Customer>(request);
            employee.CreatedAt = employee.UpdatedAt = DateUtil.GetCurrentDate();

            dbContext.Customers.Add(employee);
            await dbContext.SaveChangesAsync();

            return employee;
        }

        public Task DeleteAsync(Customer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Customer> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> Get()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int Id)
        {
            return await dbContext.Customers.FindAsync(Id);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
