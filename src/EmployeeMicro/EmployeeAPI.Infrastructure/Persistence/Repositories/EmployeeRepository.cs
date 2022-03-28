using AutoMapper;
using EmployeeAPI.Core.DTOs;
using EmployeeAPI.Core.Entities;
using EmployeeAPI.Core.Interfaces;
using EmployeeAPI.Core.Utils;
using EmployeeAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeAPI.Infrastructure.Persistence.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public EmployeeRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<Employee> AddAsync(CreateEmployeeRequest request, CancellationToken cancellationToken = default)
        {
            var employee = this.mapper.Map<Employee>(request);
            employee.CreatedAt = employee.UpdatedAt = DateUtil.GetCurrentDate();

            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();

            return employee;
        }

        public Task DeleteAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Employee> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> Get()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int Id)
        {
            return await dbContext.Employees.FindAsync(Id);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
