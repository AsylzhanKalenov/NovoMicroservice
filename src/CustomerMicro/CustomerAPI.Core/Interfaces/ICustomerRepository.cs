using CustomerAPI.Core.DTOs;
using CustomerAPI.Core.Entities;
using CustomerAPI.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerAPI.Core.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> AddAsync(CreateCustomerRequest entity, CancellationToken cancellationToken = default(CancellationToken));
        
    }
}
