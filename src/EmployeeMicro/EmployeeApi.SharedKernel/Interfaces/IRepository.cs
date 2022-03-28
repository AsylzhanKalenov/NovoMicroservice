using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApi.SharedKernel.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> Get();

        Task<T> GetById(int Id);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));

        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
