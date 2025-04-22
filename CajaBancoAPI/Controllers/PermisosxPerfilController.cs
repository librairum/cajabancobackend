using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Permisos;
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
        private IPermisosApplication _permisosApplication;
        public PermisosxPerfilController(AppDbContext context, IPermisosApplication permisosApplication)
        {
           this._context = context;
            this._permisosApplication = permisosApplication;
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
        [HttpGet]
        [Route("SpTraeMenuxPerfil")]
        public async Task<ActionResult> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {
            try
            {
                var result = await this._permisosApplication.SpTraeMenuxPerfil(codigoPerfil, codModulo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpTodoMenuxPerfil")]
        public async Task<ActionResult> SpTodoMenuxPerfil(string codigoPerfil, string codModulo)
        {
            try
            {
                var result = await this._permisosApplication.SpTodoMenuxPerfil(codigoPerfil, codModulo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpInsertaMenuxPerfil")]
        public async Task<ActionResult> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            try
            {

                var result = await this._permisosApplication.SpInsertaMenuxPerfil(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
