using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Services.Pago
{
    public class PagoService : IPagoService

    {
        private IPagoRepository _pagoRepository;

        public PagoService(IPagoRepository pagoRepositorio)
        {
            _pagoRepository = pagoRepositorio;
        }

        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGeneradoProcesoAprobado(string anio, string mes)
        {
            return await _pagoRepository.SpListaPagosGeneradoProcesoAprobado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetProcesoAprobado(string anio, string mes)
        {
            return await _pagoRepository.SpListaPagosDetProcesoAprobado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetAprobadoProcesoActualizado(string anio, string mes)
        {
            return await _pagoRepository.SpListaPagosDetAprobadoProcesoActualizado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosProcesoActualizado(string anio, string mes)
        {
            return await _pagoRepository.SpListaPagosProcesoActualizado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosActualizado()
        {
            return await _pagoRepository.SpListaPagosActualizado();
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumGeneradoProceso(string numero)
        {
            return await _pagoRepository.SpListaPagoxNumGeneradoProceso(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumAprobadoProcesoActualizado(string numero)
        {
            return await _pagoRepository.SpListaPagoxNumAprobadoProcesoActualizado(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoActualizado(string numero)
        {
            return await _pagoRepository.SpListaPagoxNumProcesoActualizado(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGenerado()
        {
            return await _pagoRepository.SpListaPagosGenerado();
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoAprobado(string numero)
        {
            return await _pagoRepository.SpListaPagoxNumProcesoAprobado(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNum(string numero)
        {
            return await _pagoRepository.SpListaPagoxNum(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagos()
        {
            return await _pagoRepository.SpListaPagos();
        }
        public async Task<ResultDto<PagoNumListResponseDTO>> SpListaPagoNumEnProcesoPago(string anio, string mes)
        {
            return await _pagoRepository.SpListaPagoNumEnProcesoPago(anio, mes);
        }
        public async Task<ResultDto<CuentasBancariasListResponseDTO>> SpListaCuentasBancarias()
        {
            return await _pagoRepository.SpListaCuentasBancarias();
        }
        public async Task<ResultDto<BancoCuentaBancariaListResponseDTO>> SpListaBancoCuentaBancaria()
        {
            return await _pagoRepository.SpListaBancoCuentaBancaria();
        }

        public async Task<ResultDto<TipoPagoCuentaNumerosListResponseDTO>> SpListaTipoPagoCuentaNumeros(string empresa, string tipopago)
        {
            return await _pagoRepository.SpListaTipoPagoCuentaNumeros(empresa, tipopago);
        }
        public async Task<ResultDto<BancosEmpresaListResponseDTO>> SpListaBancosxEmpresa(string empresa, string tipopago)
        {
            return await _pagoRepository.SpListaBancosxEmpresa(empresa, tipopago);
        }
        public async Task<ResultDto<CuentaBancariaxBancoListResponseDTO>> SpListaCuentaBancariaxBanco(string empresa, string numero)
        {
            return await _pagoRepository.SpListaCuentaBancariaxBanco(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosBancoListResponseDTO>> SpListaCuentaNumerosBanco(string empresa, string numero)
        {
            return await _pagoRepository.SpListaCuentaNumerosBanco(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaNumerosCheques(string empresa, string tipopago)
        {
            return await _pagoRepository.SpListaCuentaNumerosCheques(empresa, tipopago);
        }
        public async Task<ResultDto<CuentaNumerosComentariosListResponseDTO>> SpListaCuentaNumerosComentarios(string empresa, string numero)
        {
            return await _pagoRepository.SpListaCuentaNumerosComentarios(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosTipoPago(string empresa, string tipopago, string ctabancaria, string numero)
        {
            return await _pagoRepository.SpListaCuentaNumerosTipoPago(empresa, tipopago, ctabancaria, numero);
        }
        public async Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosxNumero(string empresa, string numero)
        {
            return await _pagoRepository.SpListaCuentaNumerosxNumero(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaBancariaCheques(string empresa, string numero)
        {
            return await _pagoRepository.SpListaCuentaBancariaCheques(empresa, numero);
        }
        public async Task<ResultDto<CuentaxBancoListResponseDTO>> SpListaCuentaxBanco(string empresa, string numero)
        {
            return await _pagoRepository.SpListaCuentaxBanco(empresa, numero);
        }
        public async Task<ResultDto<PresupuestoPagoListResponseDTO>> SpListaAprobacionPendienteFlags_1_11(int flag, string empresa, string numero, string fecha)
        {
            return await _pagoRepository.SpListaAprobacionPendienteFlags_1_11(flag, empresa, numero, fecha);
        }
        public async Task<ResultDto<AprobacionPagoListResponseDTO>> SpListaAprobacionPendienteFlags_2_4(int flag, string empresa, string numero, string fecha)
        {
            return await _pagoRepository.SpListaAprobacionPendienteFlags_2_4(flag, empresa, numero, fecha);
        }
        public async Task<ResultDto<string>> SpInsertaNumeroPagosPayCaja(NumeroPagosPayCajaCreateRequestDTO request)
        {
            return await _pagoRepository.SpInsertaNumeroPagosPayCaja(request);
        }
        public async Task<ResultDto<NumeroPagosPayCajaListResponseDTO>> SpListaNumeroPagosPayCaja(string empresa, string idpago, string numerop)
        {
            return await _pagoRepository.SpListaNumeroPagosPayCaja(empresa, idpago, numerop);
        }
        public async Task<ResultDto<DocumentosImprimirListResponseDTO>> SpListaDocumentosImprimir(string empresa, string numero)
        {
            return await _pagoRepository.SpListaDocumentosImprimir(empresa, numero);
        }
        public async Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoGenerado(string empresa, string descripcion)
        {
            return await _pagoRepository.SpListaNumeroPagoGenerado(empresa, descripcion);
        }
        public async Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoBuscar(string empresa, string descripcion, string numerop)
        {
            return await _pagoRepository.SpListaNumeroPagoBuscar(empresa, descripcion, numerop);
        }
        public async Task<ResultDto<NumeroChequeListResponseDTO>> SpListaNumeroChequeMinimo(string empresa, string descripcion)
        {
            return await _pagoRepository.SpListaNumeroChequeMinimo(empresa, descripcion);
        }
        public async Task<ResultDto<BancoCuentaPagoListResponseDTO>> SpListaBancoxCuentaPago(string empresa, string descripcion)
        {
            return await _pagoRepository.SpListaBancoxCuentaPago(empresa, descripcion);
        }
        public async Task<ResultDto<string>> SpEliminaPagosComprobReten(string empresa, string numero)
        {
            return await _pagoRepository.SpEliminaPagosComprobReten(empresa, numero);
        }
        public async Task<ResultDto<string>> SpEliminaAprobaciones(string empresa, string numero)
        {
            return await _pagoRepository.SpEliminaAprobaciones(empresa, numero);
        }
        public async Task<ResultDto<string>> SpEliminaPresupuestoDetalle(string empresa, string numero)
        {
            return await _pagoRepository.SpEliminaPresupuestoDetalle(empresa, numero);
        }
        public async Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioHoy()
        {
            return await _pagoRepository.SpListaTipoCambioHoy();
        }
        public async Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioxFecha(string fecha)
        {
            return await _pagoRepository.SpListaTipoCambioxFecha(fecha);
        }
        public async Task<ResultDto<TipoDocumentoListResponseDTO>> SpListaTipoDocumentosCodigo()
        {
            return await _pagoRepository.SpListaTipoDocumentosCodigo();
        }
        public async Task<ResultDto<EstadosListResponseDTO>> SpListaEstados()
        {
            return await _pagoRepository.SpListaEstados();
        }
        public async Task<ResultDto<string>> SpInsertaAprobacion(AprobacionCreateRequestDTO request)
        {
            return await _pagoRepository.SpInsertaAprobacion(request);
        }
        public async Task<ResultDto<AprobacionesDetalleListResponseDTO>> SpListaAprobacionPagosDetalle(int flag, string empresa, int numero)
        {
            return await _pagoRepository.SpListaAprobacionPagosDetalle(flag, empresa, numero);
        }
        public async Task<ResultDto<AprobacionesResumenListResponseDTO>> SpListaAprobacionPagosResumen(int flag, string empresa, int numero)
        {
            return await _pagoRepository.SpListaAprobacionPagosResumen(flag, empresa, numero);
        }
        public async Task<ResultDto<DetraccionDetalleListResponseDTO>> SpListaDetraccionDetalle(string empresa, string tipo, string numero, string ruc)
        {
            return await _pagoRepository.SpListaDetraccionDetalle(empresa, tipo, numero, ruc);
        }
        public async Task<ResultDto<RetencionBuscarListResponseDTO>> SpListaRetencionBuscar(string empresa, string numero, string ruc)
        {
            return await _pagoRepository.SpListaRetencionBuscar(empresa, numero, ruc);
        }
        public async Task<ResultDto<RetencionFechaEmisionListResponseDTO>> SpListaRetencionFechaEmision(string empresa, string numero, string ruc)
        {
            return await _pagoRepository.SpListaRetencionFechaEmision(empresa, numero, ruc);
        }
        public async Task<ResultDto<RetencionDetalleListResponseDTO>> SpListaRetencionDetalle(string empresa, string numero, string ruc)
        {
            return await _pagoRepository.SpListaRetencionDetalle(empresa, numero, ruc);
        }
        public async Task<ResultDto<string>> SpInsertaRetencionTotal(RetencionTotalCreateRequestDTO request)
        {
            return await _pagoRepository.SpInsertaRetencionTotal(request);
        }



    }
}
