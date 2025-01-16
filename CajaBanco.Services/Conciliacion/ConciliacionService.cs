using CajaBanco.Abstractions.IRepository;
using CajaBanco.Abstractions.IService;
using CajaBanco.DTO.Common;
using CajaBanco.DTO.Conciliacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CajaBanco.Services.Conciliacion
{
    public class ConciliacionService : IConciliacionService
    {
        private IConciliacionRepository _conciliacionRepositorio;
        public ConciliacionService(IConciliacionRepository conciliacionRepositorio)
        {
            _conciliacionRepositorio = conciliacionRepositorio;
        }
        public async Task<ResultDto<string>> SpEliminaConciliacion(string empresa, string anio, string mes, string banco, string ctaBancaria, string fila)
        {
            return await _conciliacionRepositorio.SpEliminaConciliacion(empresa, anio, mes, banco, ctaBancaria,fila);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacion(ConciliacionCreateRequestDTO request)
        {
            return await _conciliacionRepositorio.SpInsertaConciliacion(request);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionPago(ConciliacionCreateRequestDTO request)
        {
            return await _conciliacionRepositorio.SpInsertaConciliacionPago(request);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionPorPago(ConciliacionCreateRequestDTO request)
        {
            return await _conciliacionRepositorio.SpInsertaConciliacionPorPago(request);
        }

        public async Task<ResultDto<string>> SpInsertaConciliacionSaldo(ConciliacionCreateRequestDTO request)
        {
            return await _conciliacionRepositorio.SpInsertaConciliacionSaldo(request);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacion(string anio, string mes)
        {
            return await _conciliacionRepositorio.SpListaConciliacion(anio, mes);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBancariaxCuenta(string empresa, string numero)
        {
            return await _conciliacionRepositorio.SpListaConciliacionBancariaxCuenta(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBanco(string empresa, string tipoPago)
        {
            return await _conciliacionRepositorio.SpListaConciliacionBanco(empresa, tipoPago);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuenta(string empresa, string numero)
        {
            return await _conciliacionRepositorio.SpListaConciliacionCuenta(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaBancaria(string empresa, string numero)
        {
            return await _conciliacionRepositorio.SpListaConciliacionCuentaBancaria(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaNumero(string empresa, string tipoPago)
        {
            return await _conciliacionRepositorio.SpListaConciliacionCuentaNumero(empresa, tipoPago);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionImprimir(string empresa, string numero)
        {
            return await _conciliacionRepositorio.SpListaConciliacionImprimir(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionNumeroBanco(string empresa, string numero)
        {
            return await _conciliacionRepositorio.SpListaConciliacionNumeroBanco(empresa, numero);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoCambio(string empresa, string tipoPago)
        {
            return await _conciliacionRepositorio.SpListaConciliacionTipoCambio(empresa, tipoPago);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoPago(string empresa, string numero, string ctaBancaria, string tipoPago)
        {
            return await _conciliacionRepositorio.SpListaConciliacionTipoPago(empresa, numero, ctaBancaria, tipoPago);
        }

        public async Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionValidacionCuenta(string empresa, string tipoPago)
        {
            return await _conciliacionRepositorio.SpListaConciliacionValidacionCuenta(empresa, tipoPago);
        }
    }
}
