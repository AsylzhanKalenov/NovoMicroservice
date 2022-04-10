using ApiGateway.Models;
using System.Threading.Tasks;

namespace ApiGateway.Client
{
    public interface ICustomerClient
    {
        Task<LoginResponse> Login(AuthUser user);
    }
}
