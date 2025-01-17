using CajaBanco.Abstractions.IApplication;
using Microsoft.AspNetCore.Mvc;

namespace CajaPagoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagoController:Controller
    {
        //private readonly AppDbContext _context;
        //private readonly ILogger<PagoController> _logger;
        private IPagoApplication _pagoAplicacion;
        public PagoController(IPagoApplication pagoAplicacion)
        {
            this._pagoAplicacion = pagoAplicacion;
        }


        [HttpGet]
        [Route("SpList/PagosGeneradoProcesoAprobado")]
        public async Task<ActionResult> ObtenerListaPagosGeneradoProcesoAprobado(string anio, string mes)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagosGeneradoProcesoAprobado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagosDetProcesoAprobado")]
        public async Task<ActionResult> ObtenerListaPagosDetProcesoAprobado(string anio, string mes)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagosDetProcesoAprobado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagosDetAprobadoProcesoActualizado")]
        public async Task<ActionResult> ObtenerListaPagosDetAprobadoProcesoActualizadoo(string anio, string mes)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagosDetAprobadoProcesoActualizado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagosProcesoActualizado")]
        public async Task<ActionResult> ObtenerListaPagosProcesoActualizado(string anio, string mes)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagosProcesoActualizado(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagosActualizado")]
        public async Task<ActionResult> ObtenerListaPagosActualizado()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagosActualizado();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagoxNumGeneradoProceso")]
        public async Task<ActionResult> ObtenerListaPagoxNumGeneradoProceso(string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagoxNumGeneradoProceso(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
        [HttpGet]
        [Route("SpList/PagoxNumAprobadoProcesoActualizado")]
        public async Task<ActionResult> ObtenerListaPagoxNumAprobadoProcesoActualizado(string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagoxNumAprobadoProcesoActualizado(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagoxNumProcesoActualizado")]
        public async Task<ActionResult> ObtenerListaPagoxNumProcesoActualizado(string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagoxNumProcesoActualizado(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagosGenerado")]
        public async Task<ActionResult> ObtenerListaPagosGenerado()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagosGenerado();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagoxNumProcesoAprobado")]
        public async Task<ActionResult> ObtenerListaPagoxNumProcesoAprobado(string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagoxNumProcesoAprobado(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/PagoxNum")]
        public async Task<ActionResult> ObtenerListaPagoxNumo(string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagoxNum(numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/Pagos")]
        public async Task<ActionResult> ObtenerListaPagos()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/PagoNumEnProcesoPago")]
        public async Task<ActionResult> ObtenerListaPagoNumEnProcesoPago(string anio, string mes)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaPagoNumEnProcesoPago(anio, mes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
