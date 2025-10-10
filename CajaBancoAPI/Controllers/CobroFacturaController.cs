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
            catch (Exception ex)
            {
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
            catch (Exception ex)
            {
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
            catch (Exception ex)
            {
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
        public async Task<ActionResult> TraeFacturaPorCobrar(string empresa, string usuario, string clientecodigo)
        {
            try
            {
                var result = await this._aplicacion.SpTraeAyudaFacturaPorCobrar(empresa, usuario, clientecodigo);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("TraeClienteconFactura")]
        public async Task<ActionResult> TraeClienteconFactura(string empresa)
        {
            try
            {
                var result = await this._aplicacion.SpTraeClienteconfactura(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ListaDetalle")]
        public async Task<ActionResult> TraeDetalle(string empresa, string numeroRegistroCobroCab)
        {
            try
            {
                var result = await this._aplicacion.SpListaDetalle(empresa, numeroRegistroCobroCab);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("EliminaDetalle")]
        public async Task<ActionResult> EliminaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento)
        {
            try
            {
                var result = await this._aplicacion.SpEliminaDetalle(empresa, numeroRegistroCobroCab, item, tipodoc, nroDocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("ActualizaDetalle")]
        public async Task<ActionResult> ActualizaDetalle(string empresa, string numeroRegistroCobroCab, int item, string tipodoc, string nroDocumento, double pagoSoles,
            double pagoDolares, string observacion)
        {
            try
            {
                var result = await this._aplicacion.SpActualizaDetalle(empresa, numeroRegistroCobroCab,
                    item, tipodoc, nroDocumento, pagoSoles, pagoDolares, observacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        [Route("InsertaDetalle")]
        public async Task<ActionResult> InsertaDetalle(RegistroCobroDetalle registro)
        {
            try
            {
                var result = await this._aplicacion.SpInsertaDetalle(registro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
