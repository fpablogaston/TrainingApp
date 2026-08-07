using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TrainingApp.Data;
using TrainingApp.DTOs;
using TrainingApp.Models;

namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration; 

        public AuthController(AppDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UsuarioDTO usuario)
        {
            var usuarioNuevo = new Usuario
            {
                Email = usuario.Email,
                Password = usuario.Password,
            };

            _context.Usuarios.Add(usuarioNuevo);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuario)
        {
            var loginExistente = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);

            if (loginExistente == null) 
            {
                return Unauthorized();
            }

            if (loginExistente.Password == usuario.Password)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    claims: null,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            } else
            {
                return Unauthorized();
            }
        }

    }
}
