using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace api_SIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            // Aquí deberías validar el usuario y la contraseña (por ejemplo, desde una base de datos)
            bool isValidUser = true;// YourUserAuthenticationMethod(username, password);

            if (!isValidUser)
            {
                return Unauthorized(); // El usuario no está autorizado
            }

            // Generar el token JWT
            var token = GenerateJwtToken(username);
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
