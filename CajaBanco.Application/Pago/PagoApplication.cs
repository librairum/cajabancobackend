using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Banco;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Pago
{
    public class PagoApplication: IPagoApplication
    {

        private IPagoService _pagoService;

        public PagoApplication(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGeneradoProcesoAprobado(string anio, string mes)
        {
            return await this._pagoService.SpListaPagosGeneradoProcesoAprobado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetProcesoAprobado(string anio, string mes)
        {
            return await this._pagoService.SpListaPagosDetProcesoAprobado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosDetAprobadoProcesoActualizado(string anio, string mes)
        {
            return await this._pagoService.SpListaPagosDetAprobadoProcesoActualizado(anio, mes);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosProcesoActualizado(string anio, string mes)
        {
            return await this._pagoService.SpListaPagosProcesoActualizado(anio, mes);
        }
        
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosActualizado()
        {
            return await this._pagoService.SpListaPagosActualizado();
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumGeneradoProceso(string numero)
        {
            return await this._pagoService.SpListaPagoxNumGeneradoProceso(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumAprobadoProcesoActualizado(string numero)
        {
            return await this._pagoService.SpListaPagoxNumAprobadoProcesoActualizado(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoActualizado(string numero)
        {
            return await this._pagoService.SpListaPagoxNumProcesoActualizado(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagosGenerado()
        {
            return await this._pagoService.SpListaPagosGenerado();
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNumProcesoAprobado(string numero)
        {
            return await this._pagoService.SpListaPagoxNumProcesoAprobado(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagoxNum(string numero)
        {
            return await this._pagoService.SpListaPagoxNum(numero);
        }
        public async Task<ResultDto<EstadoPagoListResponseDTO>> SpListaPagos()
        {
            return await this._pagoService.SpListaPagos();
        }
        public async Task<ResultDto<PagoNumListResponseDTO>> SpListaPagoNumEnProcesoPago(string anio, string mes)
        {
            return await this._pagoService.SpListaPagoNumEnProcesoPago(anio, mes);
        }
        public async Task<ResultDto<CuentasBancariasListResponseDTO>> SpListaCuentasBancarias()
        {
            return await this._pagoService.SpListaCuentasBancarias();
        }
        public async Task<ResultDto<BancoCuentaBancariaListResponseDTO>> SpListaBancoCuentaBancaria()
        {
            return await this._pagoService.SpListaBancoCuentaBancaria();
        }
        public async Task<ResultDto<TipoPagoCuentaNumerosListResponseDTO>> SpListaTipoPagoCuentaNumeros(string empresa, string tipopago)
        {
            return await this._pagoService.SpListaTipoPagoCuentaNumeros(empresa, tipopago);
        }
        public async Task<ResultDto<BancosEmpresaListResponseDTO>> SpListaBancosxEmpresa(string empresa, string tipopago)
        {
            return await this._pagoService.SpListaBancosxEmpresa(empresa, tipopago);
        }
        public async Task<ResultDto<CuentaBancariaxBancoListResponseDTO>> SpListaCuentaBancariaxBanco(string empresa, string numero)
        {
            return await this._pagoService.SpListaCuentaBancariaxBanco(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosBancoListResponseDTO>> SpListaCuentaNumerosBanco(string empresa, string numero)
        {
            return await this._pagoService.SpListaCuentaNumerosBanco(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaNumerosCheques(string empresa, string tipopago)
        {
            return await this._pagoService.SpListaCuentaNumerosCheques(empresa, tipopago);
        }
        public async Task<ResultDto<CuentaNumerosComentariosListResponseDTO>> SpListaCuentaNumerosComentarios(string empresa, string numero)
        {
            return await this._pagoService.SpListaCuentaNumerosComentarios(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosTipoPago(string empresa, string tipopago, string ctabancaria, string numero)
        {
            return await this._pagoService.SpListaCuentaNumerosTipoPago( empresa,  tipopago,  ctabancaria,  numero);
        }
        public async Task<ResultDto<CuentaNumerosNumPagoListResponseDTO>> SpListaCuentaNumerosxNumero(string empresa, string numero)
        {
            return await this._pagoService.SpListaCuentaNumerosxNumero(empresa, numero);
        }
        public async Task<ResultDto<CuentaNumerosChequesListResponseDTO>> SpListaCuentaBancariaCheques(string empresa, string numero)
        {
            return await this._pagoService.SpListaCuentaBancariaCheques(empresa, numero);
        }
        public async Task<ResultDto<CuentaxBancoListResponseDTO>> SpListaCuentaxBanco(string empresa, string numero)
        {
            return await this._pagoService.SpListaCuentaxBanco(empresa, numero);
        }
        public async Task<ResultDto<PresupuestoPagoListResponseDTO>> SpListaAprobacionPendienteFlags_1_11(int flag, string empresa, string numero, string fecha)
        {
            return await this._pagoService.SpListaAprobacionPendienteFlags_1_11(flag,empresa, numero,fecha);
        }
        public async Task<ResultDto<AprobacionPagoListResponseDTO>> SpListaAprobacionPendienteFlags_2_4(int flag, string empresa, string numero, string fecha)
        {
            return await this._pagoService.SpListaAprobacionPendienteFlags_2_4(flag, empresa, numero, fecha);
        }
        public async Task<ResultDto<string>> SpInsertaNumeroPagosPayCaja(NumeroPagosPayCajaCreateRequestDTO request)
        {
            return await this._pagoService.SpInsertaNumeroPagosPayCaja(request);
        }
        public async Task<ResultDto<NumeroPagosPayCajaListResponseDTO>> SpListaNumeroPagosPayCaja(string empresa, string idpago, string numerop)
        {
            return await this._pagoService.SpListaNumeroPagosPayCaja(empresa,idpago,numerop);
        }
        public async Task<ResultDto<DocumentosImprimirListResponseDTO>> SpListaDocumentosImprimir(string empresa, string numero)
        {
            return await this._pagoService.SpListaDocumentosImprimir(empresa, numero);
        }
        public async Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoGenerado(string empresa, string descripcion)
        {
            return await this._pagoService.SpListaNumeroPagoGenerado(empresa, descripcion);
        }
        public async Task<ResultDto<NumerosPagPCListResponseDTO>> SpListaNumeroPagoBuscar(string empresa, string descripcion, string numerop)
        {
            return await this._pagoService.SpListaNumeroPagoBuscar(empresa, descripcion,numerop);
        }
        public async Task<ResultDto<NumeroChequeListResponseDTO>> SpListaNumeroChequeMinimo(string empresa, string descripcion)
        {
            return await this._pagoService.SpListaNumeroChequeMinimo(empresa, descripcion);
        }
        public async Task<ResultDto<BancoCuentaPagoListResponseDTO>> SpListaBancoxCuentaPago(string empresa, string descripcion)
        {
            return await this._pagoService.SpListaBancoxCuentaPago(empresa, descripcion);
        }
        public async Task<ResultDto<string>> SpEliminaPagosComprobReten(string empresa, string numero)
        {
            return await this._pagoService.SpEliminaPagosComprobReten(empresa, numero);
        }
        public async Task<ResultDto<string>> SpEliminaAprobaciones(string empresa, string numero)
        {
            return await this._pagoService.SpEliminaAprobaciones(empresa, numero);
        }
        public async Task<ResultDto<string>> SpEliminaPresupuestoDetalle(string empresa, string numero)
        {
            return await this._pagoService.SpEliminaPresupuestoDetalle(empresa, numero);
        }
        public async Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioHoy()
        {
            return await this._pagoService.SpListaTipoCambioHoy();
        }
        public async Task<ResultDto<TipoCambioListResponseDTO>> SpListaTipoCambioxFecha(string fecha)
        {
            return await this._pagoService.SpListaTipoCambioxFecha(fecha);
        }
        public async Task<ResultDto<TipoDocumentoListResponseDTO>> SpListaTipoDocumentosCodigo()
        {
            return await this._pagoService.SpListaTipoDocumentosCodigo();
        }
        public async Task<ResultDto<EstadosListResponseDTO>> SpListaEstados()
        {
            return await this._pagoService.SpListaEstados();
        }



    }
}
