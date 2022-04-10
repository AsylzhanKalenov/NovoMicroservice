using ApiGateway.Client;
using ApiGateway.Models;
using ApiGateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICustomerClient _httpClient { get; set; }
        public AuthController(ICustomerClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("getcustauth")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthToken>> GetCustomerAuthentication([FromBody] AuthUser user)
        {
            var result = await _httpClient.Login(user);
            if (Guid.Parse(result.Id) == Guid.Empty)
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new CustomerTokenService().GenerateToken(result);
        }
    }
}
