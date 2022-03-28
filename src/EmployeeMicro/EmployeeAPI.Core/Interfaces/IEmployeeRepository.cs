using EmployeeApi.SharedKernel.Interfaces;
using EmployeeAPI.Core.DTOs;
using EmployeeAPI.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeAPI.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> AddAsync(CreateEmployeeRequest entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}
