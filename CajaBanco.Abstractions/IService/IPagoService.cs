using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IService
{
    public interface IPagoService
    {
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGeneradoProcesoAprobado(string anio, string mes);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetProcesoAprobado(string anio, string mes);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetAprobadoProcesoActualizado(string anio, string mes);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosProcesoActualizado(string anio, string mes);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosActualizado();
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumGeneradoProceso(string numero);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumAprobadoProcesoActualizado(string numero);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoActualizado(string numero);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGenerado();
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoAprobado(string numero);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNum(string numero);
        public Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagos();
        public Task<ResultDto<PagoNumListResponseDTO>> SpListaPagoNumEnProcesoPago(string anio, string mes);
        public Task<ResultDto<CuentasBancariasListResponseDTO>> SpListaCuentasBancarias();
        public Task<ResultDto<BancoCuentaBancariaListResponseDTO>> SpListaBancoCuentaBancaria();
        public Task<ResultDto<TipoPagoCuentaNumerosListResponseDTO>> SpListaTipoPagoCuentaNumeros(string empresa, string tipopago);
        public Task<ResultDto<BancosEmpresaListResponseDTO>> SpListaBancosxEmpresa(string empresa, string tipopago);
        public Task<ResultDto<CuentaBancariaxBancoListResponseDTO>> SpListaCuentaBancariaxBanco(string empresa, string numero);
        public Task<ResultDto<CuentaNumerosBancoListResponseDTO>> SpListaCuentaNumerosBanco(string empresa, string numero);
        public Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaNumerosCheques(string empresa, string tipopago);
        public Task<ResultDto<CuentaNumerosComentariosListResponseDTO>> SpListaCuentaNumerosComentarios(string empresa, string numero);
        public Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosTipoPago(string empresa, string tipopago, string ctabancaria, string numero);
        public Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosxNumero(string empresa, string numero);
        public Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaBancariaCheques(string empresa, string numero);
        public Task<ResultDto<CuentaxBancoListResponseDTO>> SpListaCuentaxBanco(string empresa, string numero);
        public Task<ResultDto<PresupuestoPagoListResponseDTO>> SpListaAprobacionPendienteFlags_1_11(int flag, string empresa, string numero, string fecha);
        public Task<ResultDto<AprobacionPagoListResponseDTO>> SpListaAprobacionPendienteFlags_2_4(int flag, string empresa, string numero, string fecha);
        public Task<ResultDto<string>> SpInsertaNumeroPagosPayCaja(NumeroPagosPayCajaCreateRequestDTO request);
        public Task<ResultDto<NumeroPagosPayCajaListResponseDTO>> SpListaNumeroPagosPayCaja(string empresa, string idpago, string numerop);
        public Task<ResultDto<DocumentosImprimirListResponseDTO>> SpListaDocumentosImprimir(string empresa, string numero);
        public Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoGenerado(string empresa, string descripcion);
        public Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoBuscar(string empresa, string descripcion, string numerop);
        public Task<ResultDto<NumeroChequeListResponseDTO>> SpListaNumeroChequeMinimo(string empresa, string descripcion);
        public Task<ResultDto<BancoCuentaPagoListResponseDTO>> SpListaBancoxCuentaPago(string empresa, string descripcion);
        public Task<ResultDto<string>> SpEliminaPagosComprobReten(string empresa, string numero);
        public Task<ResultDto<string>> SpEliminaAprobaciones(string empresa, string numero);
        public Task<ResultDto<string>> SpEliminaPresupuestoDetalle(string empresa, string numero);
        public Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioHoy();
        public Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioxFecha(string fecha);
        public Task<ResultDto<TipoDocumentoListResponseDTO>> SpListaTipoDocumentosCodigo();
        public Task<ResultDto<EstadosListResponseDTO>> SpListaEstados();
        public Task<ResultDto<string>> SpInsertaAprobacion(AprobacionCreateRequestDTO request);
        public Task<ResultDto<AprobacionesDetalleListResponseDTO>> SpListaAprobacionPagosDetalle(int flag, string empresa, int numero);
        public Task<ResultDto<AprobacionesResumenListResponseDTO>> SpListaAprobacionPagosResumen(int flag, string empresa, int numero);
        public Task<ResultDto<DetraccionDetalleListResponseDTO>> SpListaDetraccionDetalle(string empresa, string tipo, string numero, string ruc);
        public Task<ResultDto<RetencionBuscarListResponseDTO>> SpListaRetencionBuscar(string empresa, string numero, string ruc);
        public Task<ResultDto<RetencionFechaEmisionListResponseDTO>> SpListaRetencionFechaEmision(string empresa, string numero, string ruc);
        public Task<ResultDto<RetencionDetalleListResponseDTO>> SpListaRetencionDetalle(string empresa, string numero, string ruc);
        public Task<ResultDto<string>> SpInsertaRetencionTotal(RetencionTotalCreateRequestDTO request);





    }
}
