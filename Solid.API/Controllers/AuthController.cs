using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Solid.API.Models;
using Solid.Core.Entities;
using Solid.Core.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, ICustomerService customerService)
        {
            _customerService = customerService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var customer = _customerService.GetCustomers(null).First(c => (c.Name is null || c.Name.Equals(loginModel.UserName)) && (c.Password is null || c.Password.Equals(loginModel.Password)));
            if (customer is null)
                return Unauthorized();

            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, customer.Name is null ? "" : customer.Name),
                new(ClaimTypes.Email, customer.Email is null? "":customer.Email),
                new(ClaimTypes.StreetAddress, customer.Address is null ? "" : customer.Address)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
    }
}
