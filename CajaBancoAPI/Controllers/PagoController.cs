using CajaBanco.Abstractions.IApplication;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Pago;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        // --------------------------LIST-----------------------
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
        [HttpGet]
        [Route("SpList/CuentasBancarias")]
        public async Task<ActionResult> ObtenerCuentasBancarias()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentasBancarias();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/BancoCuentasBancarias")]
        public async Task<ActionResult> ObtenerBancoCuentasBancarias()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaBancoCuentaBancaria();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/TipoPagoCuentaNumeros")]
        public async Task<ActionResult> ObtenerListaTipoPagoCuentaNumeros(string empresa, string tipopago)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaTipoPagoCuentaNumeros(empresa, tipopago);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/BancosxEmpresa")]
        public async Task<ActionResult> ObtenerListaBancosxEmpresa(string empresa, string tipopago)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaBancosxEmpresa(empresa, tipopago);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/CuentaBancariaxBanco")]
        public async Task<ActionResult> ObtenerListaCuentaBancariaxBanco(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaBancariaxBanco(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/CuentaNumerosBanco")]
        public async Task<ActionResult> ObtenerListaCuentaNumerosBanco(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaNumerosBanco(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("SpList/CuentaNumerosCheques")]
        public async Task<ActionResult> ObtenerListaCuentaNumerosCheques(string empresa, string tipopago)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaNumerosCheques(empresa, tipopago);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("SpList/CuentaNumerosComentarios")]
        public async Task<ActionResult> ObtenerListaCuentaNumerosComentarios(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaNumerosComentarios(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/CuentaNumerosTipoPago")]
        public async Task<ActionResult> ObtenerListaCuentaNumerosTipoPago(string empresa, string tipopago, string ctabancaria, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaNumerosTipoPago(empresa, tipopago, ctabancaria, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("SpList/CuentaNumerosxNumero")]
        public async Task<ActionResult> ObtenerListaCuentaNumerosxNumero(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaNumerosxNumero(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("SpList/CuentaBancariaCheques")]
        public async Task<ActionResult> ObtenerListaCuentaBancariaCheques(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaBancariaCheques(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/CuentaxBanco")]
        public async Task<ActionResult> ObtenerListaCuentaxBanco(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaCuentaxBanco(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/AprobacionPendiente")]
        public async Task<ActionResult> ObtenerListaAprobacionPendiente(int flag, string empresa, string numero, string fecha)
        {
            try
            {
                if (flag == 1 || flag==11)
                {
                    var result = await this._pagoAplicacion.SpListaAprobacionPendienteFlags_1_11(flag, empresa, numero, fecha);
                    return Ok(result);

                }
                else if (flag == 2 || flag == 4)
                {
                    var result = await this._pagoAplicacion.SpListaAprobacionPendienteFlags_2_4(flag, empresa, numero, fecha);
                    return Ok(result);

                }
                else
                {
                    return BadRequest("flag incorecto");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/NumeroPagosPayCaja")]
        public async Task<ActionResult> ObtenerListaNumeroPagosPayCaja(string empresa, string idpago, string numerop)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaNumeroPagosPayCaja(empresa, idpago,numerop);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/DocumentosImprimir")]
        public async Task<ActionResult> ObtenerListaDocumentosImprimir(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaDocumentosImprimir(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/NumeroPagosGenerado")]
        public async Task<ActionResult> ObtenerListaNumeroPagoGenerado(string empresa, string descripcion)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaNumeroPagoGenerado(empresa, descripcion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/NumeroPagosBuscar")]
        public async Task<ActionResult> ObtenerListaNumeroPagoBuscar(string empresa, string descripcion,string numerop)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaNumeroPagoBuscar(empresa, descripcion, numerop);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/NumeroChequeMinimo")]
        public async Task<ActionResult> ObtenerListaNumeroChequeMinimo(string empresa, string descripcion)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaNumeroChequeMinimo(empresa, descripcion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/BancoxCuentaPago")]
        public async Task<ActionResult> ObtenerListaBancoxCuentaPago(string empresa, string descripcion)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaBancoxCuentaPago(empresa, descripcion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/TipoCambioHoy")]
        public async Task<ActionResult> ObtenerTipoCambioHoy()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaTipoCambioHoy();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/TipoCambioxFecha")]
        public async Task<ActionResult> ObtenerTipoCambioxFecha(string fecha)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaTipoCambioxFecha(fecha);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/TipoDocumentosCodigo")]
        public async Task<ActionResult> ObtenerTipoDocumentosCodigo()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaTipoDocumentosCodigo();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/Estados")]
        public async Task<ActionResult> ObtenerEstados()
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaEstados();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("SpList/AprobacionPagos")]
        public async Task<ActionResult> ObtenerListaAprobacionPagos(int flag, string empresa, int numero)
        {
            try
            {
                if (flag == 1)
                {
                    var result = await this._pagoAplicacion.SpListaAprobacionPagosDetalle(flag, empresa, numero);
                    return Ok(result);

                }
                else if (flag == 2)
                {
                    var result = await this._pagoAplicacion.SpListaAprobacionPagosResumen(flag, empresa, numero);
                    return Ok(result);

                }
                else
                {
                    return BadRequest("flag incorecto");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/DetraccionDetalle")]
        public async Task<ActionResult> ObtenerDetraccionDetalle(string empresa, string tipo, string numero, string ruc)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaDetraccionDetalle(empresa,tipo,numero,ruc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/RetencionBuscar")]
        public async Task<ActionResult> ObtenerRetencionBuscar(string empresa, string numero, string ruc)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaRetencionBuscar(empresa, numero, ruc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/RetencionFechaEmision")]
        public async Task<ActionResult> ObtenerRetencionFechaEmision(string empresa, string numero, string ruc)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaRetencionFechaEmision(empresa, numero, ruc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("SpList/RetencionDetalle")]
        public async Task<ActionResult> ObtenerRetencionDetalle(string empresa, string numero, string ruc)
        {
            try
            {
                var result = await this._pagoAplicacion.SpListaRetencionDetalle(empresa, numero, ruc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // --------------------------CREATE-----------------------
        [HttpPost]
        [Route("SpCreate/NumeroPagosPayCaja")]
        public async Task<ActionResult> InsertaNumeroPagosPayCaja(NumeroPagosPayCajaCreateRequestDTO request)
        {
            try
            {
                var result = await this._pagoAplicacion.SpInsertaNumeroPagosPayCaja(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpCreate/Aprobacion")]
        public async Task<ActionResult> InsertaAprobacion(AprobacionCreateRequestDTO request)
        {
            try
            {
                var result = await this._pagoAplicacion.SpInsertaAprobacion(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SpCreate/RetencionTotal")]
        public async Task<ActionResult> InsertaRetencionTotal(RetencionTotalCreateRequestDTO request)
        {
            try
            {
                var result = await this._pagoAplicacion.SpInsertaRetencionTotal(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // --------------------------DELETE-----------------------
        [HttpDelete]
        [Route("SpDelete/PagosComprobReten")]
        public async Task<ActionResult> EliminaPagosComprobReten(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpEliminaPagosComprobReten(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpDelete/Aprobaciones")]
        public async Task<ActionResult> EliminaAprobaciones(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpEliminaAprobaciones(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("SpDelete/PresupuestoDetalle")]
        public async Task<ActionResult> EliminaPresupuestoDetalle(string empresa, string numero)
        {
            try
            {
                var result = await this._pagoAplicacion.SpEliminaPresupuestoDetalle(empresa, numero);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
