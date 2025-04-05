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

        [HttpGet]
        [Route("SpTraeRegContableDet")]
        public async Task<ActionResult> SpTraeRegContableDet(string empresa, string anio,
            string mes, string libro, string voucher, double nroOrden)
        {
            try
            {
                var result = await this._aplicacion.SpTraeRegContableDet(empresa,anio, mes, 
                    libro, voucher, nroOrden);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
