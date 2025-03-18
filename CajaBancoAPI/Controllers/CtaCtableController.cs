using CajaBanco.Abstractions.IApplication;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CtaCtableController : Controller
    {
        private ICtaCtableApplication _aplicacion;
        public CtaCtableController(ICtaCtableApplication aplicacion) {
            this._aplicacion = aplicacion;
        }

        [HttpGet]
        [Route("SpTraeDetalle")]
        public async Task<ActionResult> SpTraeDetalle(string empresa, string numero)
        {
            try
            {
                var result = await this._aplicacion.SpTraeDetalle(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTraeCabecera")]
        public async Task<ActionResult> SpTraeCabecera(string empresa, string numero)
        {
            try
            {
                var result = await this._aplicacion.SpTraeCabecera(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
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
