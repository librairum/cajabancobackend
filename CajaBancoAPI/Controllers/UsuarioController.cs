using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CajaBancoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(AppDbContext context, ILogger<UsuarioController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //método para listar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }
        // metodo para crear un usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            try
            {
                if(usuario == null)
                {
                    return BadRequest("Usuario Invalido");
                }
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok(new {message="Usuario Registrado"});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar usuario");
                return StatusCode(500, new {message="Error interno al crear el usuario"});
            }
        }

        //metodo para actualizar
        [HttpPut("{sistema}/{nombre}")]
        public async Task<ActionResult> UpdateUsuario(string sistema,string nombre, Usuario usuario)
        {
            if (sistema != usuario.Sistema || nombre !=usuario.Nombre)
            {
                return BadRequest("Los datos correctos proporcionados no coinciden con los identificadores");
            }
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario actualizado exitosamente" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExiste(sistema, nombre))
                {
                    return NotFound();
                }
                throw;
            }
        }

        //método para eliminar
        [HttpDelete("{sistema}/{nombre}")]
        public async Task<ActionResult> DeleteUsuario(string sistema, string nombre)
        {
            var usuario = await _context.Usuario.FindAsync(sistema, nombre);
            if (usuario == null)
            {
                _logger.LogWarning($"Usuario no encontrado: Sistema={sistema}, Nombre={nombre}");
                return NotFound(new { message = "Usuario no encontrado." });
            }

            _context.Usuario.Remove(usuario);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el usuario.");
                return StatusCode(500, new { message = "Error interno al eliminar usuario." });
            }
        }
        private bool UsuarioExiste(string sistema, string nombre)
        {
            return _context.Usuario.Any(x => x.Sistema == sistema && x.Nombre == nombre);
        }
    }
}
