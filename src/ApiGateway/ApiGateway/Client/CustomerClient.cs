using ApiGateway.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiGateway.Client
{
    public class CustomerClient : ICustomerClient
    {
        private HttpClient _httpClient { get; set; }
        public CustomerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> Login(AuthUser user)
        {
            var login = JsonSerializer.Serialize(user);

            var requestContent = new StringContent(login, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Auth/login", requestContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            //return content;
            var customer = JsonSerializer.Deserialize<LoginResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return customer;
        }
    }
}
