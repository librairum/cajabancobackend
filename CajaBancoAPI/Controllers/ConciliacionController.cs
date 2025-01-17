using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Conciliacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CajaBancoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConciliacionController : Controller
    {
        private IConciliacionApplication _conciliacionApplication;
        public ConciliacionController(IConciliacionApplication conciliacionApplication)
        {
            this._conciliacionApplication = conciliacionApplication;
        }
        //INSERTAR: 
        [HttpPost]
        [Route("SpInsertaConciliacion")]
        public async Task<ActionResult> SpInsertaConciliacion(ConciliacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._conciliacionApplication.SpInsertaConciliacion(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaConciliacionPorPago")]
        public async Task<ActionResult> SpInsertaConciliacionPorPago(ConciliacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._conciliacionApplication.SpInsertaConciliacionPorPago(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaConciliacionPago")]
        public async Task<ActionResult> SpInsertaConciliacionPago(ConciliacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._conciliacionApplication.SpInsertaConciliacionPago(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SpInsertaConciliacionSaldo")]
        public async Task<ActionResult> SpInsertaConciliacionSaldo(ConciliacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._conciliacionApplication.SpInsertaConciliacionSaldo(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //LISTAR:

        [HttpGet]
        [Route("SpListaConciliacion")]
        public async Task<ActionResult> SpListaConciliacion(string anio, string mes)
        {
            try
            {
                var result = await this._conciliacionApplication.SpListaConciliacion(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaConciliacionTipoCambio")]
        public async Task<ActionResult> SpListaConciliacionTipoCambio(string empresa, string tipoPago)
        {
            try
            {
                var result = await this._conciliacionApplication.SpListaConciliacionTipoCambio(empresa, tipoPago);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaConciliacionBanco")]
        public async Task<ActionResult> SpListaConciliacionBanco(string empresa, string tipoPago)
        {
            try
            {
                var result = await this._conciliacionApplication.SpListaConciliacionBanco(empresa, tipoPago);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaConciliacionBancariaxCuenta")]
        public async Task<ActionResult> SpListaConciliacionBancariaxCuenta(string empresa, string numero)
        {
            try
            {
                var result = await this._conciliacionApplication.SpListaConciliacionBancariaxCuenta(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpListaConciliacionNumeroBanco")]
        public async Task<ActionResult> SpListaConciliacionNumeroBanco(string empresa, string numero)
        {
            try
            {
                var result = await this._conciliacionApplication.SpListaConciliacionNumeroBanco(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //ELIMINAR:

        [HttpDelete]
        [Route("SpDelete")]
        public async Task<ActionResult> SpEliminaConciliacion(string empresa, string anio, string mes, string banco, string ctaBancaria, string fila)
        {
            try
            {
                var result = await this._conciliacionApplication.SpEliminaConciliacion(empresa, anio, mes, banco, ctaBancaria, fila);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
