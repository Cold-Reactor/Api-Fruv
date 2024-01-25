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
using api_SIF.Models.EmpleadosN;

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
            var empleado = _context.empleados.FirstOrDefault(x => x.id_empleado == user.id_empleado);

            var usuarioR = new UsuarioRequest();
            usuarioR.username = model.userName;
            
            usuarioR.id_empleado = user.id_empleado;
            if (empleado!=null) {
                usuarioR.no_empleado = empleado.no_empleado;
                usuarioR.id_sucursal = empleado.id_sucursal;
            }
            // Generar el token JWT
            var token = GenerateJwtToken(usuarioR);
            var jwtSettings = _configuration.GetSection("JwtSettings");

            DateTime expiracion_acceso = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtSettings["ExpirationDays"]));
            return Ok(new {token,usuarioR.id_empleado,usuarioR.no_empleado,usuarioR.id_sucursal,expiracion_acceso});
        }
        private string GenerateJwtTokenActualizacionExpiracion(string username)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            DateTime tokenExpiration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["ExpirationDays"]));
            if (tokenExpiration <= DateTime.UtcNow.AddMinutes(5)) // Renovar si el token expira en 5 minutos o menos
            {
                tokenExpiration = DateTime.UtcNow.AddMinutes(1); // Renovar por una hora
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, username)
                    // Puedes agregar más claims aquí para personalizar el token (roles, etc.)
                }),
                Audience = jwtSettings["Audience"],
                Issuer = jwtSettings["Issuer"],
                Expires = tokenExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateJwtToken(UsuarioRequest user)
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
                new Claim(ClaimTypes.Name, user.username),

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
