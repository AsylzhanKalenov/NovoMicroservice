using EmployeeAPI.Core.Entities;
using EmployeeAPI.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Employee> UserManager;
        private readonly SignInManager<Employee> SignInManager;
        private readonly ILogger<AuthController> Logger;

        public AuthController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, ILogger<AuthController> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest login)
        {

            var signInResult = await SignInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: false);
            if (!signInResult.Succeeded)
            {
                Logger.LogWarning("Access failed for user {UserName}", login.Email);
                return BadRequest();
            }

            var customer = await UserManager.FindByNameAsync(login.Email);

            var res = new LoginResponse
            {
                Id = customer.Id.ToString(),
                Firstname = customer.FirstName,
                Lastname = customer.LastName,
                Birthdate = customer.BirthDate,
                Email = customer.Email
            };

            return res;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<IdentityError>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Register(CreateEmployeeRequest model)
        {
            var customer = new Employee()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await UserManager.CreateAsync(customer, model.Password);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            foreach (var error in result.Errors)
            {
                Logger.LogError("Registration failed for user {UserName}", model.Email);
                ModelState.AddModelError("error", error.Description);
            }

            return BadRequest(result.Errors);
        }
    }
}
