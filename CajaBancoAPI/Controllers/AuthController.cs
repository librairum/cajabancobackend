using CajaBancoAPI.Context;
using CajaBancoAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CajaBancoAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
      
    public class AuthController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController (AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Nombre) || string.IsNullOrEmpty(request.Clave))
            {
                return BadRequest("Los campos 'Nombre' y 'Clave' son obligatorios.");
            }
            var user = await _context.Usuario.Select(u => new Usuario
                {
                    Nombre = u.Nombre ?? "",
                    Clave = u.Clave ?? "",
                    // claves necesarias
                }).FirstOrDefaultAsync(u => u.Nombre == request.Nombre && u.Clave == request.Clave);

            if (user == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }

            var token = _jwtService.GenerateToken(user); // Genera el token
            return Ok(new { Token = token });
        }
    }

    public class UsuarioLoginRequest
    {
        //public string Sistema { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}
