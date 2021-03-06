using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogAPI.SharedKernel.Interfaces
{
    public interface IRepository<T>
    {
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    }
}
