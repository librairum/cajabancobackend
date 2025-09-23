using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.CobroFactura;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CobroFacturaController : Controller
    {
        private ICobroFacturaApplication _aplicacion;
        
        public CobroFacturaController(ICobroFacturaApplication aplicacion)
        {
            this._aplicacion = aplicacion;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> ObtenerLista(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._aplicacion.SpListaCabecera(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Inserta")]
        public async Task<ActionResult> InsertaCab(RegistroCobro registro)
        {
            try
            {
                var result = await this._aplicacion.SpInsertaCabecera(registro);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Actualiza")]
        public async Task<ActionResult> ActualizaCab(RegistroCobro registro)
        {
            try
            {
                var result = await this._aplicacion.SpActualizaCabecera(registro);
                return Ok(result);

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Elimina")]
        public async Task<ActionResult> EliminaCab(string empresa,
            string anio, string mes, string numero)
        {
            try
            {
                var result = await this._aplicacion.SpEliminaCabecera(empresa, anio, mes, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("TraeFacturaPorCobrar")]
        public async Task<ActionResult> TraeFacturaPorCobrar(string empresa, string anio, string mes, string usuario)
        {
            try
            {
                var result = await this._aplicacion.SpTraeAyudaFacturaPorCobrar(empresa, anio, mes, usuario);
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
