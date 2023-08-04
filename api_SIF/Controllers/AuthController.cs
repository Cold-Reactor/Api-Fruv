using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using api_SIF.Models;
using System.Threading.Tasks;
using api_SIF.dbContexts;
using System.Linq;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly RHDBContext _context;

        public AuthController(IConfiguration configuration, RHDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            bool isValidUser = true;
            var user = _context.usuarios.FirstOrDefault(x=>x.user== model.userName);
            if (user == null || !(model.password.Equals(user.password)))
            {
                isValidUser = false;
            }
            if (!isValidUser)
            {
                return Unauthorized(); // El usuario no está autorizado
            }

            // Generar el token JWT
            var token = GenerateJwtToken(model.userName);
            return Ok(new { token });
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
            var a = jwtSettings["SecretKey"];
            var b = jwtSettings["Issuer"];
            var c = jwtSettings["Audience"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, username)
                    // Puedes agregar más claims aquí para personalizar el token (roles, etc.)
                }),
                Audience = jwtSettings["Audience"],
                Issuer = jwtSettings["Issuer"],

                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtSettings["ExpirationDays"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
