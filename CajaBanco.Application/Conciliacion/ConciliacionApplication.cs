using CajaBanco.Abstractions.IApplication;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Conciliacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Application.Conciliacion
{
    public class ConciliacionApplication : IConciliacionApplication
    {
        private IConciliacionService _conciliacionService;
        public ConciliacionApplication(IConciliacionService conciliacionService)
        {
            _conciliacionService = conciliacionService;
        }
        public async Task<ResultDto<string>> SpEliminaConciliacion(string empresa, string anio, string mes, string banco, string ctaBancaria, string fila)
        {
            return await this._conciliacionService.SpEliminaConciliacion(empresa, anio, mes, banco, ctaBancaria, fila);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacion(ConciliacionCreateRequestDTO request)
        {
            return await this._conciliacionService.SpInsertaConciliacion(request);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionPago(ConciliacionCreateRequestDTO request)
        {
            return await this._conciliacionService.SpInsertaConciliacionPago(request);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionPorPago(ConciliacionCreateRequestDTO request)
        {
            return await this._conciliacionService.SpInsertaConciliacionPorPago(request);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionSaldo(ConciliacionCreateRequestDTO request)
        {
            return await this._conciliacionService.SpInsertaConciliacionSaldo(request);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacion(string anio, string mes)
        {
            return await this._conciliacionService.SpListaConciliacion(anio, mes);
        }

        public async Task<ResultDto<BancariaxCuentaListResponseDTO>> SpListaConciliacionBancariaxCuenta(string empresa, string numero)
        {
            return await this._conciliacionService.SpListaConciliacionBancariaxCuenta(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionBancoListResponseDTO>> SpListaConciliacionBanco(string empresa, string tipoPago)
        {
            return await this._conciliacionService.SpListaConciliacionBanco(empresa, tipoPago);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuenta(string empresa, string numero)
        {
            return await this._conciliacionService.SpListaConciliacionCuenta(empresa, numero);
        }

        public async Task<ResultDto<CuentaBancariaListResponseDTO>> SpListaConciliacionCuentaBancaria(string empresa, string numero)
        {
            return await this._conciliacionService.SpListaConciliacionCuentaBancaria(empresa, numero);
        }

        public async Task<ResultDto<CuentaValidacionListResponseDTO>> SpListaConciliacionCuentaNumero(string empresa, string tipoPago)
        {
            return await this._conciliacionService.SpListaConciliacionCuentaNumero(empresa, tipoPago);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionImprimir(string empresa, string numero)
        {
            return await this._conciliacionService.SpListaConciliacionImprimir(empresa, numero);
        }

        public async Task<ResultDto<CuentaBancoListResponseDTO>> SpListaConciliacionNumeroBanco(string empresa, string numero)
        {
            return await this._conciliacionService.SpListaConciliacionNumeroBanco(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoCambio(string empresa, string tipoPago)
        {
            return await this._conciliacionService.SpListaConciliacionTipoCambio(empresa, tipoPago);
        }

        public async Task<ResultDto<CuentaBancariaListResponseDTO.Numero>> SpListaConciliacionTipoPago(string empresa, string numero, string ctaBancaria, string tipoPago)
        {
            return await this._conciliacionService.SpListaConciliacionTipoPago(empresa, numero, ctaBancaria, tipoPago);
        }

        public async Task<ResultDto<CuentaValidacionListResponseDTO>> SpListaConciliacionValidacionCuenta(string empresa, string tipoPago)
        {
            return await this._conciliacionService.SpListaConciliacionValidacionCuenta(empresa, tipoPago);
        }
    }
}
