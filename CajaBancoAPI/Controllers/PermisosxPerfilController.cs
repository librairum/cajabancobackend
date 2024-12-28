using CajaBancoAPI.Context;
using CajaBancoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CajaBancoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermisosxPerfilController : Controller
    {
        private readonly AppDbContext _context;

        public PermisosxPerfilController(AppDbContext context)
        {
           this._context = context;
        }

        [HttpGet("{codigoPerfil}/{cCodModulo}")]
        public async Task<ActionResult<IEnumerable<PermisosxPerfil>>> GetMenuPerfiles(string codigoPerfil,
            string cCodModulo)
        {
            if (_context == null) {
                throw new Exception("dbcontext es nulo");
            }
            // Ejecutar el procedimiento almacenado
            var codigoPerfilParametro = new SqlParameter("@codigoPerfil", codigoPerfil);
            var cCodModuloParametro = new SqlParameter("@cCodModulo", cCodModulo);
            var menuPerfiles = await _context.ListaMenuxPerfil
                .FromSqlRaw("exec Spu_Seg_Trae_menuxperfil @codigoPerfil, @cCodModulo",
                codigoPerfilParametro, cCodModuloParametro)
                .ToListAsync();

            // Check if the list is empty
            if (!menuPerfiles.Any())
            {
                return NotFound();
            }

            return menuPerfiles;
        }
    }
}
