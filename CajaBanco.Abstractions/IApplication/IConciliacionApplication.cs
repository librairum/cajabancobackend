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
        public Task<ResultDto<string>> SpInsertaConciliacion(ConciliacionCreateRequestDTO request); 
        public Task<ResultDto<string>> SpInsertaConciliacionPorPago(ConciliacionCreateRequestDTO request);
        public Task<ResultDto<string>> SpInsertaConciliacionPago(ConciliacionCreateRequestDTO request);
        public Task<ResultDto<string>> SpInsertaConciliacionSaldo(ConciliacionCreateRequestDTO request);

        //LISTAR:
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacion(string anio, string mes); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoCambio(string empresa, string tipoPago); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionBanco(string empresa, string tipoPago); 
        public Task<ResultDto<BancariaxCuentaListResponseDTO>> SpListaConciliacionBancariaxCuenta(string empresa, string numero); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionNumeroBanco(string empresa, string numero); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaNumero(string empresa, string tipoPago); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionImprimir(string empresa, string numero); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionTipoPago(string empresa, string numero, string ctaBancaria, string tipoPago); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuenta(string empresa, string numero); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionValidacionCuenta(string empresa, string tipoPago); 
        public Task<ResultDto<ConciliacionListResponseDTO>> SpListaConciliacionCuentaBancaria(string empresa, string numero); 

        //DELETE:
        public Task<ResultDto<string>> SpEliminaConciliacion(string empresa, string anio, string mes,string banco, string ctaBancaria, string fila); 
    }
}
