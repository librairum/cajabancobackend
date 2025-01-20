using CajaBanco.Abstractions.IApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContabilidadController : Controller
    {
        private IContabilidadApplication _contabilidadApplication;
        public ContabilidadController(IContabilidadApplication contabilidadApplication)
        {
            _contabilidadApplication = contabilidadApplication;
        }
        //LISTAR:
        [HttpGet]
        [Route("SpListaAsientoContable")]
        public async Task<ActionResult> SpListaAsientoContable(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoContable(empresa, usuario, valor, anio, mes, libro, codBanco, ctaBancaria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaAsientoContableInd")]
        public async Task<ActionResult> SpListaAsientoContableInd(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoContableInd(empresa, usuario, valor, anio, mes, libro, codBanco);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaLote")]
        public async Task<ActionResult> SpListaAsientoContableLot(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoContableLot(empresa, usuario, valor, anio, mes, libro, codBanco);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaLiquidacion")]
        public async Task<ActionResult> SpListaAsientoContableLiquidacion(string empresa, string usuario, string valor, string anio, string mes, string libro, string ctaBancaria)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoContableLiquidacion(empresa, usuario, valor, anio, mes, libro, ctaBancaria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaRetencion")]
        public async Task<ActionResult> SpListaAsientoContableRetencion(string empresa, string usuario, string valor, string anio, string mes, string libro, string cuenta, string flagnumvoucher)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoContableRetencion(empresa, usuario, valor, anio, mes, libro, cuenta, flagnumvoucher);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListasientoSinRelacion")]
        public async Task<ActionResult> SpListaAsientoContableSR(string empresa, string usuario, string valor, string anio, string mes, string libro, string codBanco, string ctaBancaria)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoContableSR(empresa, usuario, valor, anio, mes, libro, codBanco, ctaBancaria);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaDocumento")]
        public async Task<ActionResult> SpListaDocumentoContabiliza(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaDocumentoContabiliza(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaDocIndividual")]
        public async Task<ActionResult> SpListaDocumentoIndividual(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaDocumentoIndividual(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaDocLote")]
        public async Task<ActionResult> SpListaDocumentoLote(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaDocumentoLote(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route(" SpListaDocLiquidacion")]
        public async Task<ActionResult> SpListaDocumentoLiquidacion(string empresa, string anio, string mes)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaDocumentoLiquidacion(empresa, anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaDocRetencion")]
        public async Task<ActionResult> SpListaDocumentoRetencion(string anio, string mes)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaDocumentoRetencion(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaBanco")]
        public async Task<ActionResult> SpListaAsientoCuentaBanco()
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaAsientoCuentaBanco();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaValidacionBanco")]
        public async Task<ActionResult> SpListaValidacionBanco(string empresa, string usuario, string proceso)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaValidacionBanco(empresa, usuario, proceso);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpListaValidacionIndividual")]
        public async Task<ActionResult> SpListaValidacionDetIndividual(string usuario, string proceso)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaValidacionDetIndividual(usuario, proceso);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaValidacionLote")]
        public async Task<ActionResult> SpListaValidacionDetLote(string usuario, string proceso)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaValidacionDetLote(usuario, proceso);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaValidacionLiquidacion")]
        public async Task<ActionResult> SpListaValidacionLiquidacion(string empresa, string usuario, string proceso)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaValidacionLiquidacion(empresa, usuario, proceso);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaValidacionRetencion")]
        public async Task<ActionResult> SpListaValidacionRetencion(string usuario, string proceso)
        {
            try
            {
                var result = await this._contabilidadApplication.SpListaValidacionRetencion(usuario, proceso);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //ELIMINAR
        [HttpDelete]
        [Route("SpEliminaAsientoContable")]
        public async Task<ActionResult> SpEliminaAsientoContable(string empresa, string usuario, string valor)
        {
            try
            {
                var result = await this._contabilidadApplication.SpEliminaAsientoContable(empresa, usuario, valor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaAsientoContableInd")]
        public async Task<ActionResult> SpEliminaAsientoContableInd(string empresa, string usuario, string valor)
        {
            try
            {
                var result = await this._contabilidadApplication.SpEliminaAsientoContableInd(empresa, usuario, valor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaLiquidacion")]
        public async Task<ActionResult> SpEliminaAsientoContableLiquidacion(string empresa, string valor)
        {
            try
            {
                var result = await this._contabilidadApplication.SpEliminaAsientoContableLiquidacion(empresa, valor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpEliminaRetencion")]
        public async Task<ActionResult> SpEliminaAsientoContableRetencion(string usuario, string valor)
        {
            try
            {
                var result = await this._contabilidadApplication.SpEliminaAsientoContableRetencion(usuario, valor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
