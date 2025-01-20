using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Liquidacion;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiquidacionController : Controller
    {
        private ILiquidacionApplication _liquidacionApplication;
        public LiquidacionController(ILiquidacionApplication liquidacionApplication)
        {
            _liquidacionApplication = liquidacionApplication;
        }
        //INSERTAR
        [HttpPost]
        [Route("SpInsertaLiquidacionTemp")]
        public async Task<ActionResult> SpInsertaLiquidacionTemp(LiquidacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._liquidacionApplication.SpInsertaLiquidacionTemp(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaPago")]
        public async Task<ActionResult> SpInsertaLiquidacionPago(LiquidacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._liquidacionApplication.SpInsertaLiquidacionPago(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaRegistro")]
        public async Task<ActionResult> SpInsertaLiquidacionRegistro(LiquidacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._liquidacionApplication.SpInsertaLiquidacionRegistro(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaTempPago")]
        public async Task<ActionResult> SpInsertaLiquidacionTempPago(LiquidacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._liquidacionApplication.SpInsertaLiquidacionTempPago(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaDetTemp")]
        public async Task<ActionResult> SpInsertaLiquidacionDetTemp(LiquidacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._liquidacionApplication.SpInsertaLiquidacionDetTemp(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //ELIMINAR:
        [HttpDelete]
        [Route("SpEliminaLiquidacion")]
        public async Task<ActionResult> SpEliminaLiquidacion(string empresa, string codigoLiq)
        {
            try
            {
                var result = await this._liquidacionApplication.SpEliminaLiquidacion(empresa,codigoLiq);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaDetalle")]
        public async Task<ActionResult> SpEliminaLiquidacionDetalle(string empresa, string codigoLiq)
        {
            try
            {
                var result = await this._liquidacionApplication.SpEliminaLiquidacionDetalle(empresa, codigoLiq);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaTemp")]
        public async Task<ActionResult> SpEliminaLiquidacionTemp(string empresa, string codigoLiqTemp)
        {
            try
            {
                var result = await this._liquidacionApplication.SpEliminaLiquidacionTemp(empresa, codigoLiqTemp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaUsuario")]
        public async Task<ActionResult> SpEliminaLiquidacionUsuario(string empresa, string usuario)
        {
            try
            {
                var result = await this._liquidacionApplication.SpEliminaLiquidacionUsuario(empresa, usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaRegistro")]
        public async Task<ActionResult> SpEliminaLiquidacionRegistro(string empresa, string codigoLiq, string item)
        {
            try
            {
                var result = await this._liquidacionApplication.SpEliminaLiquidacionRegistro(empresa, codigoLiq, item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //LISTAR:
        [HttpGet]
        [Route("SpListaLiquidacion")]
        public async Task<ActionResult> SpListaLiquidacion(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiquidacion(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaPago")]
        public async Task<ActionResult> SpListaLiquidacionPago(string empresa, string numero)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiquidacionPago(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaMenu")]
        public async Task<ActionResult> SpListaLiquidacionMenu()
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiquidacionMenu();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaModulo")]
        public async Task<ActionResult> SpListaLiquidacionModulo(string fecha)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiquidacionModulo(fecha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaDocumentoPago")]
        public async Task<ActionResult> SpListaLiquidacionDocumentoPago(string empresa)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiquidacionDocumentoPago(empresa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaPendiente")]
        public async Task<ActionResult> SpListaLiqPendienteTodo(string empresa, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqPendienteTodo(empresa, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaPendienteRetencion")]
        public async Task<ActionResult> SpListaLiqPendienteRetencion(string empresa, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqPendienteRetencion(empresa, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaPendienteDetraccion")]
        public async Task<ActionResult> SpListaLiqPendienteDetraccion(string empresa, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqPendienteDetraccion(empresa, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaPendientePeriodo")]
        public async Task<ActionResult> SpListaLiqPendientePeriodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqPendientePeriodo(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaVencimientoDetraccion")]
        public async Task<ActionResult> SpListaLiqVencimientoDetraccion(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqVencimientoDetraccion(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaVencimientoRetencion")]
        public async Task<ActionResult> SpListaLiqVencimientoRetencion(string empresa, string fechaVenci1, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqVencimientoRetencion(empresa, fechaVenci1, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaVencimiento")]
        public async Task<ActionResult> SpListaLiqVencimientoTodo(string empresa, string fechaVenci1, string fechaVenci2, string fechaAnio, string fechaMes, string buscar, string buscar1, string buscar2)
        {
            try
            {
                var result = await this._liquidacionApplication.SpListaLiqVencimientoTodo(empresa, fechaVenci1, fechaVenci2, fechaAnio, fechaMes, buscar, buscar1, buscar2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
