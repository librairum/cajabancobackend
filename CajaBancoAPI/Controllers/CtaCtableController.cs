using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.RegistroContable;
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


        [HttpGet]
        [Route("SpTraeAyudaHabyMov")]
        public async Task<ActionResult> SpTraeAyudaHabyMov(string empresa, string anio)
        {
            try
            {
                var result = await this._aplicacion.SpTraeAyudaHabyMov(empresa, anio);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("SpTraeAyudaPRoveedor")]
        public async Task<ActionResult> SpTraeAyudaPRoveedor(string empresa)
        {
            try
            {
                var result = await this._aplicacion.SpTraeAyudaProveedor(empresa, "02");
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTraeAyudaTipoDocumentos")]
        public async Task<ActionResult> SpTraeAyudaTipoDocumentos(string empresa)
        {
            try
            {
                var result = await this._aplicacion.SpTraeAyudaTipoDocumentos(empresa);
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
