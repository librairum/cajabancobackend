using Azure.Core;
using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using CajaBanco.DTO.Presupuesto;
using CajaBanco.Repository.Presupuesto;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresupuestoController : Controller
    {
        private IPresupuestoApplication _app;
        public PresupuestoController(IPresupuestoApplication aplicacion)
        {
            this._app = aplicacion;
        }


        [HttpGet]
        [Route("SpTraeProveedores")]
        public async Task<ActionResult> ObtenerListProveedores(string empresa)
        {
            try
            {
                var result = await this._app.SpTraeProveedores(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpListaDocPendientes")]
        public async Task<ActionResult> ObtenerListDocPendientes(string empresa,  string ruc="" , string numerodocumento = "")
        {
            try
            {
                var result = await this._app.SpListaDocPendientes(empresa,  ruc, numerodocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("SpList")]
        public async Task<ActionResult> ObtenerLista(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._app.SpLista(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpInsert")]
        public async Task<ActionResult> SpInserta(PresupuestoRequest request)
        {
            try
            {
                var result = await this._app.Inserta(request);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpActualiza")]
        public async Task<ActionResult> SpActualiza(PresupuestoRequest request)
        {
            try
            {
                var result = await this._app.SpActualiza(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("SpElimina")]
        public async Task<ActionResult> SpElimina(string empresa , string numero)
        {
            try
            {
                var result = await this._app.SpElimina(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpTraeTipoPago")]
        public async Task<ActionResult> SpTraeTipoPago(string empresa)
        {
            try
            {
                var result = await  this._app.SpTraeTipoPago(empresa);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        #region "Detalle"
        [HttpPost]
        [Route("SpInsertaDet")]
        public async Task<ActionResult> InsertaDet(string Empresa,
            string numeropresupuesto, string tipoaplicacion, string fechapresupuesto, string bcoliquidacion, string xmlDetalle)
        {
            try
            {
                var result = await this._app.InsertaDet(Empresa, numeropresupuesto, tipoaplicacion, fechapresupuesto, bcoliquidacion, xmlDetalle);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaDet")]
        public async Task<ActionResult> SpEliminaDet(string empresa, 
            string codigoDetallePresupuesto, 
            string numeroPresupuesto)
        {
            try
            {
                var result = await this._app.SpEliminaDet(empresa, codigoDetallePresupuesto, numeroPresupuesto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("SpActualizaDet")]
        public async Task<ActionResult> SpActualizaDet(PresupuestoDetRequest request)
        {
            try
            {
                var result = await this._app.SpActualizaDet(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpListaDet")]
        public async Task<ActionResult> SpListaDet(string empresa, 
            string numerodocumento)
        {
            try
            {
                var result = await this._app.SpListaDet(empresa, numerodocumento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


    }
}
