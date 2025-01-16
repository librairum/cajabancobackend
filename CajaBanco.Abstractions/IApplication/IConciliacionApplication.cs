using CajaBanco.DTO.Conciliacion;
using CajaBanco.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco.Abstractions.IApplication
{
    public interface IConciliacionApplication
    {
        //INSERT:
        public Task<ResultDto<string>> SpInsertaConciliacion(ConciliacionCreateRequestDTO request); //Frm_Ban_Conciliacion: Spu_Ban01_Insert_DetConciliacion: 
        public Task<ResultDto<string>> SpInsertaConciliacionPorPago(ConciliacionCreateRequestDTO request); // Spu_Ban_Ins_ConciliacionxPago
        public Task<ResultDto<string>> SpInsertaConciliacionPago(ConciliacionCreateRequestDTO request);
        public Task<ResultDto<string>> SpInsertaConciliacionSaldo(ConciliacionCreateRequestDTO request);

        //LISTAR:
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacion(string anio, string mes); //Spu_Ban01_Trae_Conciliacion - flag 1: Spu_Ban_Trae_Conciliacion
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoCambio(string empresa, string tipoPago); //flag 1:Spu_Ban_Trae_TipoCambio
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBanco(string empresa, string tipoPago); //flag 2: Spu_Ban_Trae_ConciliacionBanco
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBancariaxCuenta(string empresa, string numero); //flag 3: Spu_Ban_Trae_CuentaBancariaxCuenta
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionNumeroBanco(string empresa, string numero); //flag 4: Spu_Ban_Trae_CuentaNumeroBanco
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaNumero(string empresa, string tipoPago); //flag 5: Spu_Ban_Trae_CuentaNumeroBancaria
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionImprimir(string empresa, string numero); //flag 6:Spu_Ban_Trae_VerificacionImprimir
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoPago(string empresa, string numero, string ctaBancaria, string tipoPago); //flag 7: Spu_Ban_Trae_CuentaBancariaNumeroxTipoPago
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuenta(string empresa, string numero); //flag 8: Spu_Ban_Trae_CuentaNumeroxCuenta
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionValidacionCuenta(string empresa, string tipoPago); //flag 9: Spu_Ban_Trae_CuentaBancariaValidacion
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaBancaria(string empresa, string numero); //flag 10: Spu_Ban_Trae_CuentaBancaria

        //DELETE:
        public Task<ResultDto<string>> SpEliminaConciliacion(string empresa, string anio, string mes,string banco, string ctaBancaria, string fila); //Spu_Ban_Del_ConciliacionPago 
    }
}
