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


    }
}
