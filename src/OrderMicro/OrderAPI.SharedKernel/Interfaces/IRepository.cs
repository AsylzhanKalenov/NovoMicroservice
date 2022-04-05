using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderAPI.SharedKernel.Interfaces
{
    public interface IRepository<T>
    {
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    }
}
