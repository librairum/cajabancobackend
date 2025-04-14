using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioApplication _aplicacion;

        public UsuarioController (IUsuarioApplication aplicacion)
        {
            this._aplicacion = aplicacion;
        }
        
        [HttpGet]
        [Route("SpLista")]
        public async Task<ActionResult> SpLista(string codigo = "")
        {
            try
            {
                var result = await this._aplicacion.SpTraer(codigo);
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("SpInserta")]
        public async Task<ActionResult> SpInserta(UsuarioRequest request)
        {
            try
            {
                var result = await this._aplicacion.SpInserta(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("SpActualiza")]
        public async Task<ActionResult> SpActualiza(UsuarioRequest request)
        {
            try
            {
                var result = await this._aplicacion.SpActualiza(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("SpElimina")]
        public async Task<ActionResult> SpElimina(string codigo)
        {
            try
            {
                var result = await this._aplicacion.SpElimina(codigo);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
