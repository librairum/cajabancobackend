using Microsoft.AspNetCore.Mvc;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Autenticacion;
using CajaBancoAPI.Context;


namespace CajaBancoAPI.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class AutenticacionController : Controller
    {

        private IAutenticacionApplication _authAplicacion;
        //private readonly AppDbContext _context;

        public AutenticacionController(IAutenticacionApplication authAplicacion)
        {
            this._authAplicacion = authAplicacion;
        }

        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> ObtenerUsuario(string nombreusuario, string claveusuario, string codigoempresa)
        {
            try
            {
                var result = await this._authAplicacion.SpAccesoUsuario(nombreusuario, claveusuario, codigoempresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTraeMenuxPerfil")]
        public async Task<ActionResult> SpTraeMenuxPerfil(string codigoPerfil, string codModulo)
        {
            try
            {
                var result = await this._authAplicacion.SpTraeMenuxPerfil(codigoPerfil, codModulo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        //[Route("SpListAutenticacion")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
