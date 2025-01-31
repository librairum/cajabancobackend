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

        #region "Detalle"
        [HttpPost]
        [Route("SpInsertaDet")]
        public async Task<ActionResult> InsertaDet(PresupuestoDetRequest request)
        {
            try
            {
                var result = await this._app.InsertaDet(request);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaDet")]
        public async Task<ActionResult> SpEliminaDet(string empresa, string ruc, string tipodoc,
            string nrodoc, string codigo)
        {
            try
            {
                var result = await this._app.SpEliminaDet(empresa, ruc, tipodoc, nrodoc, codigo);
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
            string numerodocumento, string fechapresupuesto)
        {
            try
            {
                var result = await this._app.SpListaDet(empresa, numerodocumento, fechapresupuesto);
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
